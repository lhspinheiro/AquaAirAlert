using AquaAirAlert.Application.Security;
using AquaAirAlert.Communication.Request;
using AquaAirAlert.Communication.Response;
using AquaAirAlert.Exception;
using AquaAirAlert.Infrastructure.Data;
using AquaAirAlert.Infrastructure.Security.Tokens;
using Microsoft.EntityFrameworkCore;

namespace AquaAirAlert.Application.UseCase.Login;

public class LoginUseCase : ILoginUseCase
{

    private readonly IAcessTokenGenerator  _tokenGenerator;
    public LoginUseCase(IAcessTokenGenerator tokenGenerator)
    {
        _tokenGenerator = tokenGenerator;
    }
    
    public async Task<ResponseSuccessLogin> Login(RequestLogin request)
    {
        var dbContext = new AppDbContext();
        
        
        var entity = await dbContext.Users.AsNoTracking()
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