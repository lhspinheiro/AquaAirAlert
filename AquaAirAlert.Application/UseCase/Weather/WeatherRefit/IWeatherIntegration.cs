using AquaAirAlert.Communication.Response;

namespace AquaAirAlert.Application.UseCase.Weather.WeatherRefit;

public interface IWeatherIntegration
{
    Task <WeatherResponse> GetWeather (string city);
    
    Task <ResponseAirPolluition>  GetAirPolluition (float lat, float lon);
}