using AquaAirAlert.Domain.Security.Tokens;
using AquaAirAlert.Infrastructure.Security.Tokens;

namespace AquaAirAlert.Api.Token;

public class HttpContextTokenValue : ITokenProvider
{
    private readonly IHttpContextAccessor _contextAccessor;

    public HttpContextTokenValue(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }
    
    public string tokenOnRequest()
    {
        var authorization = _contextAccessor.HttpContext!.Request.Headers.Authorization.ToString();
        
        //"Bearer 12345abcdef"
        
        return authorization["Bearer ".Length..].Trim();
    }
}