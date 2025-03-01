using AquaAirAlert.Communication.Response;

namespace AquaAirAlert.Application.UseCase.WeatherRefit;

public interface IWeatherIntegration
{
    Task <WeatherResponse> GetWeather (string city);
}