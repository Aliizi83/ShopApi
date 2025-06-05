using Microsoft.EntityFrameworkCore;
using Shop.Api.Extensions;
using Shop.Api.Filters.Global;
using Shop.Infrastructure;
using Shop.Infrastructure.Persistence;
using Shop.Infrastructure.Persistence.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ShopDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

// Register Seeders
builder.Services.AddTransient<ISeeder<ShopDbContext>, UserSeeder>();

//Auto Check Validation for all controllers
builder.Services.AddControllers(options => { options.Filters.Add(new ValidateModelAttribute()); });


//Binding repositories adn services
builder.Services.MapRepositories();
builder.Services.MapServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shop.Api v1");
            c.RoutePrefix = string.Empty;
        }
    );
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast");

//Run Seeders
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ShopDbContext>();
    var seeders = scope.ServiceProvider.GetServices<ISeeder<ShopDbContext>>();

    foreach (var seeder in seeders)
    {
        seeder.Seed(dbContext);
    }

    dbContext.SaveChanges();
}

app.UseAuthentication();
app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}