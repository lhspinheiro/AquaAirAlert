using AquaAirAlert.Application.Security;
using AquaAirAlert.Communication.Request;
using AquaAirAlert.Communication.Response;
using AquaAirAlert.Exception;
using AquaAirAlert.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AquaAirAlert.Application.UseCase.Login;

public class LoginUseCase
{
    public async Task<ResponseSuccessLogin> Login(RequestLogin request)
    {
        var dbContext = new AppDbContext();
        
        var entity = await dbContext.Users.FirstOrDefaultAsync(user => user.Email.Equals(request.Email));
        if (entity is null)
            throw new InvalidLoginException();

        var cryptography = new BCryptAlgorithm();
        var passwordIsValid = cryptography.Verify(request.Password, entity);
        
        if (passwordIsValid is false)
            throw new InvalidLoginException();

        return new ResponseSuccessLogin
        {
            Sucess = $"Login successful! {entity.Name} has been authenticated and logged in!"
        };
    }
}