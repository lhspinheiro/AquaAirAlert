using AquaAirAlert.Application.Security;
using AquaAirAlert.Communication.Request;
using AquaAirAlert.Communication.Response;
using AquaAirAlert.Domain.Security.Tokens;
using AquaAirAlert.Exception;
using AquaAirAlert.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AquaAirAlert.Application.UseCase.Users.Login;

public class LoginUseCase : ILoginUseCase
{

    private readonly IAcessTokenGenerator  _tokenGenerator;
    private readonly AppDbContext  _appDbContext;
    public LoginUseCase(IAcessTokenGenerator tokenGenerator, AppDbContext appDbContext)
    {
        _tokenGenerator = tokenGenerator;
        _appDbContext = appDbContext;
    }
    
    public async Task<ResponseSuccessLogin> Login(RequestLogin request)
    {
        
        var entity = await _appDbContext.Users.AsNoTracking()
            .FirstOrDefaultAsync(r => EF.Functions.Collate(r.Email, "NOCASE") == request.Email);
        if (entity is null)
            throw new InvalidLoginException();

        var cryptography = new BCryptAlgorithm();
        var passwordIsValid = cryptography.Verify(request.Password, entity);
        
        if (passwordIsValid is false)
            throw new InvalidLoginException();
        
        return new ResponseSuccessLogin
        {
            Sucess = $"Login successful! {entity.Name} has been authenticated and logged in!",
            Token = _tokenGenerator.Generate(entity)
        };
    }
}