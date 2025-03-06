using AquaAirAlert.Application.UseCase.WeatherRefit;
using AquaAirAlert.Communication.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AquaAirAlert.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AirPollutionController : ControllerBase
    {
        
        private readonly IWeatherIntegration _weatherIntegration;

        public AirPollutionController(IWeatherIntegration  weatherIntegration)
        {
            _weatherIntegration = weatherIntegration;
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
