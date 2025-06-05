using Shop.Domain.Repository.User;
using Shop.Infrastructure.Repository.Postgres.User;

namespace Shop.Api.Extensions;

public static class BindRepositories
{
    public static IServiceCollection MapRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, PostgresUserRepository>();
        
        return services;
    }
}