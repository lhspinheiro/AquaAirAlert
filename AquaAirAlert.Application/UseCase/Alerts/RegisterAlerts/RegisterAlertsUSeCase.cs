using AquaAirAlert.Communication.Request;
using AquaAirAlert.Communication.Response;
using AquaAirAlert.Domain.Entities;
using AquaAirAlert.Exception;
using AquaAirAlert.Infrastructure.Data;
using AquaAirAlert.Infrastructure.Services.LoggedUser;
using AutoMapper;

namespace AquaAirAlert.Application.UseCase.Alerts.RegisterAlerts;

public class RegisterAlertsUSeCase : IRegisterAlertsUSeCase
{
    private readonly ILoggedUser _loggedUser;
    private readonly AppDbContext  _dbContext;
    private readonly IMapper _mapper;
    

    public RegisterAlertsUSeCase(ILoggedUser  loggedUser, AppDbContext dbContext, IMapper mapper)
    {
        _loggedUser = loggedUser;
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<ResponseAlert> Execute(AlertRequest request)
    {
        await Validate(request);

        var loggedUser = await _loggedUser.Get();
        
        var entity = _mapper.Map<alert>(request);
        entity.UserId = loggedUser.Id;
        
        await _dbContext.Alerts.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        
        return _mapper.Map<ResponseAlert>(entity);
    }
    
    private async Task Validate(AlertRequest request)
    {
        var validator = new RequestValidation();
        
        var result = await validator.ValidateAsync(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
            
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}