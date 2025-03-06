using AquaAirAlert.Communication.Response;
using Microsoft.Extensions.Options;
using Refit;

namespace AquaAirAlert.Application.UseCase.InterfacesRefit;

public interface IWeatherIntegrationRefit
{
    private const string api_key = "277cf4aea8499d4457fb51e04af5e1dc";
    
    
    [Get("/data/2.5/weather?q={city}&appid=" + api_key +  "&lang=pt_br&units=metric")]
    Task <ApiResponse<WeatherResponse>> GetWeather  (string city);
    
    [Get("/data/2.5/air_pollution?lat={lat}&lon={lon}&appid=" + api_key)]
    Task <ApiResponse<ResponseAirPolluition>>  GetAirPollution (float lat, float lon);
}