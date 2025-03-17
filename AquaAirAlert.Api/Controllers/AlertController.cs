using AquaAirAlert.Application.UseCase.Delete;
using AquaAirAlert.Application.UseCase.GetAllAlerts;
using AquaAirAlert.Application.UseCase.RegisterAlerts;
using AquaAirAlert.Application.UseCase.UpdateAlerts;
using AquaAirAlert.Communication.Request;
using AquaAirAlert.Communication.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaAirAlert.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class AlertController : ControllerBase
    {
        
        [HttpPost]
        [ProducesResponseType(typeof(ResponseAlert), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
       
        public async Task<IActionResult> Register([FromServices]IRegisterAlertsUSeCase useCase, [FromBody] AlertRequest request)
        {
            var response = await useCase.Execute(request);
            
            return Created(string.Empty, response);
        }
        

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAll([FromServices]IGetAllAlertsUseCase useCase)
        {
            
            var response = await useCase.Execute();
            
            if (response != null)
                return Ok(response);
            
            return NoContent();

        }
        
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseAlert), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromServices]IUpdateRequestUseCase useCase, [FromRoute] long id, [FromBody]AlertRequest request )
        {
            var result = await useCase.Execute(id, request);
            
            if (result == null)
                return NotFound();
            
            return Ok(result);
        }
        
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromServices]IDeleteAlertUseCase useCase, [FromRoute] long id)
        {
            var result = await useCase.Delete(id);
    
            if  (result)
                return Ok();
            
            return NotFound();
        }
    }
}
