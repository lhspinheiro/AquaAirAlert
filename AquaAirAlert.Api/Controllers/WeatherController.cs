using AquaAirAlert.Application.UseCase.WeatherRefit;
using AquaAirAlert.Communication.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaAirAlert.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {

        [HttpGet]
        [Authorize] 
        [Route("{city}")]
        public async Task<ActionResult<WeatherResponse>> Get([FromServices]IWeatherIntegration weatherIntegration  ,  [FromRoute]string city)
        {
           var result = await weatherIntegration.GetWeather(city);

           if (result is null)
               return NotFound("City not found");
           
           return Ok(result);
        }
        
    }
}
