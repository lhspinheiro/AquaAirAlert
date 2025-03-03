using AquaAirAlert.Application.UseCase.WeatherRefit;
using AquaAirAlert.Communication.Response;
using Microsoft.AspNetCore.Mvc;

namespace AquaAirAlert.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherIntegration _weatherIntegration;

        public WeatherController(IWeatherIntegration  weatherIntegration)
        {
            _weatherIntegration = weatherIntegration;
        }
        
        [HttpGet]
        [Route("{city}")]
        public async Task<ActionResult<WeatherResponse>> Get([FromRoute]string city)
        {
           var result = await _weatherIntegration.GetWeather(city);

           if (result is null)
               return NotFound("City not found");
           
           return Ok(result);
        }

        [HttpGet]
        [Route("{lat}/{lon}")]

        public async Task<ActionResult<ResponseAirPolluition>> getAirPollution([FromRoute] float lat,
            [FromRoute] float lon)
        {
            var result = await _weatherIntegration.GetAirPolluition(lat, lon);
            
            if  (result is null)
                return NotFound("Location not found");
            
            return Ok(result);
        }
        
    }
}
