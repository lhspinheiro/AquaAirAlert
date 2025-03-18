using AquaAirAlert.Application.UseCase.Delete;
using AquaAirAlert.Application.UseCase.GetAlertsByLocation;
using AquaAirAlert.Application.UseCase.GetAllAlerts;
using AquaAirAlert.Application.UseCase.GetMyAlerts;
using AquaAirAlert.Application.UseCase.InterfacesRefit;
using AquaAirAlert.Application.UseCase.Login;
using AquaAirAlert.Application.UseCase.RegisterAlerts;
using AquaAirAlert.Application.UseCase.RegisterUser;
using AquaAirAlert.Application.UseCase.UpdateAlerts;
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
        services.AddScoped<IWeatherIntegration, WeatherIntegration>();
        services.AddScoped<IRegisterAlertsUSeCase, RegisterAlertsUSeCase>();
        services.AddScoped<IGetAllAlertsUseCase, GetAllAlertsUseCase>();
        services.AddScoped<IDeleteAlertUseCase, DeleteAlertUseCase>();
        services.AddScoped<IUpdateRequestUseCase, UpdateRequestUseCase>();
        services.AddScoped<ILoginUseCase, LoginUseCase>();
        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        services.AddScoped<IGetByLocationUseCase, GetByLocationUseCase>();
        services.AddScoped<IGetMyAlertsUseCase, GetMyAlertsUseCase>();
    }
}