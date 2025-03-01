using AquaAirAlert.Application.UseCase.InterfacesRefit;
using AquaAirAlert.Communication.Response;

namespace AquaAirAlert.Application.UseCase;

public class WeatherIntegration : IWeatherIntegration
{
    
     private readonly IWeatherIntegrationRefit _weatherIntegrationRefit;

     public WeatherIntegration(IWeatherIntegrationRefit weatherIntegrationRefit)
     {
         _weatherIntegrationRefit = weatherIntegrationRefit;
     }
    
    public async Task<WeatherResponse> GetWeather(string city)
    {
        
        var responseApi = await _weatherIntegrationRefit.GetWeather(city);
        
        if (responseApi != null && responseApi.IsSuccessStatusCode)
        {
           return responseApi.Content;
        }  
        return null; 
    }
    
}