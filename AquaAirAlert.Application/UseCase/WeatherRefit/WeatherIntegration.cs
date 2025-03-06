using AquaAirAlert.Application.UseCase.WeatherRefit;
using AquaAirAlert.Communication.KeyModel;
using AquaAirAlert.Communication.Response;
using Microsoft.Extensions.Options;

namespace AquaAirAlert.Application.UseCase.InterfacesRefit;

public class WeatherIntegration : IWeatherIntegration
{
    
     private readonly IWeatherIntegrationRefit _weatherIntegrationRefit;
     private readonly ApiKey  _apiKey;

     public WeatherIntegration(IOptions<ApiKey> apiKey, IWeatherIntegrationRefit weatherIntegrationRefit)
     {
         _apiKey = apiKey.Value;
         _weatherIntegrationRefit = weatherIntegrationRefit;
     }
    
     
    public async Task<WeatherResponse> GetWeather(string city)
    {
        string api_key = _apiKey.key;
        
        var responseApi = await _weatherIntegrationRefit.GetWeather(city, api_key);
        
        if (responseApi != null && responseApi.IsSuccessStatusCode)
        {
           return responseApi.Content;
        }  
        return null; 
    }

    public async Task<ResponseAirPolluition> GetAirPolluition(float lat, float lon)
    {
        
        string api_key = _apiKey.key;
        
        var responseApi = await _weatherIntegrationRefit.GetAirPollution(lat, lon, api_key);

        if (responseApi != null && responseApi.IsSuccessStatusCode)
        {
            var responseContent = responseApi.Content;

            
            responseContent.SetDescriptionForAqi();

            return responseContent;
        }
        return null;
    }
}