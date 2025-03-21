using AquaAirAlert.Application.UseCase.Users.Login;
using AquaAirAlert.Communication.Request;
using AquaAirAlert.Communication.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace AquaAirAlert.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseSuccessLogin), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromServices]ILoginUseCase useCase, [FromBody] RequestLogin request)
        {
            var result = await useCase.Login(request);
            
            return Ok(result);
            
        }
    }
}
