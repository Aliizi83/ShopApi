using Shop.Application.Interfaces.Auth;
using Shop.Infrastructure.Services.Auth;

namespace Shop.Api.Extensions;

public static class BindServices
{
    public static IServiceCollection MapServices(this IServiceCollection services)
    {
        services.AddScoped<ILoginService, LoginService>();
        
        return services;
    }
}