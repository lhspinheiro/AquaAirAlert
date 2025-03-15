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
        [HttpGet]
        [Route("{lat}/{lon}")]
        public async Task<ActionResult<ResponseAirPolluition>> getAirPollution([FromServices]IWeatherIntegration weatherIntegration,
            [FromRoute] float lat, [FromRoute] float lon)
        {
            var result = await weatherIntegration.GetAirPolluition(lat, lon);
            
            if  (result is null)
                return NotFound("Location not found");
            
            return Ok(result);
        }
    }
}
