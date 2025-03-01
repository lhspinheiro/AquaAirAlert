
using AquaAirAlert.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace AquaAirAlert.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddRepository(services);
    }

    private static void AddRepository(IServiceCollection services)
    {
        services.AddScoped<IReadOnlyRepository, Repository.Repository>();
    }
}