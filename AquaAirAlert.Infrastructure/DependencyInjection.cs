using AquaAirAlert.Domain.Security.Tokens;
using AquaAirAlert.Infrastructure.Security.Tokens;
using AquaAirAlert.Infrastructure.Services.LoggedUser;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AquaAirAlert.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddLoggedUser(services);
        AddToken(services, configuration);
    }
    
    private static void AddToken(IServiceCollection services, IConfiguration configuration)
    {
        var experationTimeMinutes = configuration.GetValue<uint>("Settings:Jwt:ExpiresMinutes");
        var signinKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");

        services.AddScoped<IAcessTokenGenerator>(config => new JwtTokenGenerator(experationTimeMinutes, signinKey!));
    }

    private static void AddLoggedUser(IServiceCollection services)
    {
        services.AddScoped<ILoggedUser, LoggedUser>();
    }
}