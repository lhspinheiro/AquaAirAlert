using AquaAirAlert.Application.Security;
using AquaAirAlert.Communication.Request;
using AquaAirAlert.Communication.Response;
using AquaAirAlert.Domain.Security.Tokens;
using AquaAirAlert.Exception;
using AquaAirAlert.Infrastructure.Data;
using AutoMapper;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace AquaAirAlert.Application.UseCase.Users.RegisterUser;

public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IAcessTokenGenerator  _tokenGenerator;
    private readonly AppDbContext  _appDbContext;
    private readonly IMapper _mapper;

    public RegisterUserUseCase(IAcessTokenGenerator  tokenGenerator, AppDbContext appDbContext, IMapper mapper)
    {
        _tokenGenerator = tokenGenerator;
        _appDbContext = appDbContext;
        _mapper = mapper;
    }
    
    public async Task<ResponseUserRegistered> Execute(UserRequest request)
    {
        await Validate(request, _appDbContext);

        var encryptedPassword = new BCryptAlgorithm();

        var entity = _mapper.Map<User>(request);
        entity.Password = encryptedPassword.HashPassword(request.Password);
        
        await _appDbContext.Users.AddAsync(entity);
        await _appDbContext.SaveChangesAsync();

        return _mapper.Map<ResponseUserRegistered>(entity);

    }
    
    private async Task Validate( UserRequest request, AppDbContext dbcontext)
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