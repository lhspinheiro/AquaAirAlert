using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AquaAirAlert.Domain.Security.Tokens;
using AquaAirAlert.Infrastructure.Data;
using AquaAirAlert.Infrastructure.Security.Tokens;
using Microsoft.EntityFrameworkCore;

namespace AquaAirAlert.Infrastructure.Services.LoggedUser;

public class LoggedUser : ILoggedUser
{
    private readonly AppDbContext _dbContext;
    private readonly ITokenProvider _tokenProvider;

    public LoggedUser(AppDbContext  dbContext, ITokenProvider  tokenProvider)
    {
        _dbContext = dbContext;
        _tokenProvider = tokenProvider;
    }
    
    public async Task<User> Get()
    {
        string token = _tokenProvider.tokenOnRequest();
        
        var tokenHandler = new JwtSecurityTokenHandler();

        var jwtSecurityToken = tokenHandler.ReadJwtToken(token);

        var identifier = jwtSecurityToken.Claims.First(claim => claim.Type == ClaimTypes.Sid).Value;

        return await _dbContext.Users.AsNoTracking().FirstAsync(user => user.UserIdentifier == Guid.Parse(identifier));
    }
}