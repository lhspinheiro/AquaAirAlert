using AquaAirAlert.Application.UseCase.GetAllAlerts;
using AquaAirAlert.Application.UseCase.RegisterAlerts;
using AquaAirAlert.Communication.Request;
using AquaAirAlert.Communication.Response;
using AquaAirAlert.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace AquaAirAlert.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AlertController : ControllerBase
    {
        
        [HttpPost]
        [ProducesResponseType(typeof(ResponseAlert), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Register(AlertRequest request)
        {
            var useCase = new RegisterAlertsUSeCase();

            var response = await useCase.Execute(request);
            
            return Created(string.Empty, response);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAll()
        {
            var dbContext = new AppDbContext();
            
            var useCase = new GetAllAlertsUseCase(dbContext);
            
            var response = await useCase.Execute();
            
            if (response != null)
                return Ok(response);
            
            return NoContent();

        }
    }
}
