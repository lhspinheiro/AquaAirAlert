using AquaAirAlert.Application.UseCase.RegisterUser;
using AquaAirAlert.Communication.Request;
using AquaAirAlert.Communication.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AquaAirAlert.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegisterUserController : ControllerBase
    {
        
        [HttpPost]
        [ProducesResponseType(typeof(ResponseUserRegistered), statusCode: StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromServices]IRegisterUserUseCase useCase, [FromBody] UserRequest request)
        {
            var register = await useCase.Execute(request);
            
            return Created(string.Empty, register);
        }
    }
}
    