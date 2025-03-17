using AquaAirAlert.Application.Security;
using AquaAirAlert.Communication.Request;
using AquaAirAlert.Communication.Response;
using AquaAirAlert.Exception;
using AquaAirAlert.Infrastructure.Data;
using AquaAirAlert.Infrastructure.Security.Tokens;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace AquaAirAlert.Application.UseCase.RegisterUser;

public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IAcessTokenGenerator  _tokenGenerator;

    public RegisterUserUseCase(IAcessTokenGenerator  tokenGenerator)
    {
        _tokenGenerator = tokenGenerator;
    }
    
    public async Task<ResponseUserRegistered> Execute(UserRequest request)
    {
        var dbcontext = new AppDbContext();
        
        await Validate(request, dbcontext);

        var encryptedPassword = new BCryptAlgorithm();

        var entity = new User()
        {
            Name = request.Name,
            Email = request.Email,
            Password = encryptedPassword.HashPassword(request.Password),
        };
        
        
        await dbcontext.Users.AddAsync(entity);
        await dbcontext.SaveChangesAsync();

        return new ResponseUserRegistered 
        {
            Name = entity.Name,
            Email = entity.Email,
            Token = _tokenGenerator.Generate(entity)
        };

    }
    
    private async Task Validate( UserRequest request    , AppDbContext dbcontext)
    {
        var validator = new RegisterValidator();
        var result = validator.Validate(request);
        
        var existEmail = await dbcontext.Users.AnyAsync(user => user.Email.Equals(request.Email));
        
        if (existEmail)
            result.Errors.Add(new ValidationFailure("Email",  "Email already exists."));
        
        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
            
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}