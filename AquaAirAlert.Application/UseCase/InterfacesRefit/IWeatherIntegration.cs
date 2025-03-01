using AquaAirAlert.Communication.Response;

namespace AquaAirAlert.Application.UseCase.InterfacesRefit;

public interface IWeatherIntegration
{
    Task <WeatherResponse> GetWeather (string city);
}