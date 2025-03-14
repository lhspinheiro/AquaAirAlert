using AquaAirAlert.Application.UseCase.Delete;
using AquaAirAlert.Application.UseCase.InterfacesRefit;
using AquaAirAlert.Application.UseCase.WeatherRefit;
using Microsoft.Extensions.DependencyInjection;

namespace AquaAirAlert.Application;

public static class DependencyInjection
{
    public static void addApplcation(this IServiceCollection services)
    {
        addUseCase(services);
    }

    private static void addUseCase(IServiceCollection services)
    {
        services.AddScoped<DeleteAlertUseCase>();
        services.AddScoped<IWeatherIntegration, WeatherIntegration>();
    }
}