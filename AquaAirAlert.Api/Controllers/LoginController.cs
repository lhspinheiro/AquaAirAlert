using AquaAirAlert.Application.UseCase.Login;
using AquaAirAlert.Communication.Request;
using AquaAirAlert.Communication.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace AquaAirAlert.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseSuccessLogin), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] RequestLogin request)
        {
            var useCase = new LoginUseCase();

            var result = await useCase.Login(request);
            
            return Ok(result);
            
        }
    }
}
