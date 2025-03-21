using AquaAirAlert.Application.UseCase.Alerts.Delete;
using AquaAirAlert.Application.UseCase.Alerts.GetAlertsByLocation;
using AquaAirAlert.Application.UseCase.Alerts.GetAllAlerts;
using AquaAirAlert.Application.UseCase.Alerts.GetMyAlerts;
using AquaAirAlert.Application.UseCase.Alerts.RegisterAlerts;
using AquaAirAlert.Application.UseCase.Alerts.UpdateAlerts;
using AquaAirAlert.Application.UseCase.Users.Login;
using AquaAirAlert.Application.UseCase.Users.RegisterUser;
using AquaAirAlert.Application.UseCase.Weather.WeatherRefit;
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