using AquaAirAlert.Communication.Response;
using Microsoft.Extensions.Options;
using Refit;

namespace AquaAirAlert.Application.UseCase.InterfacesRefit;

public interface IWeatherIntegrationRefit
{
    [Get("/data/2.5/weather?q={city}&appid={api_key}&lang=pt_br&units=metric")]
    Task <ApiResponse<WeatherResponse>> GetWeather  (string city, string api_key);
    
    [Get("/data/2.5/air_pollution?lat={lat}&lon={lon}&appid={api_key}")]
    Task <ApiResponse<ResponseAirPolluition>>  GetAirPollution (float lat, float lon, string api_key);
}