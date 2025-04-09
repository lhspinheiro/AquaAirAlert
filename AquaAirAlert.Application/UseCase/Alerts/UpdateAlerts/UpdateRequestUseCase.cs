using AquaAirAlert.Application.UseCase.Alerts.RegisterAlerts;
using AquaAirAlert.Communication.Request;
using AquaAirAlert.Communication.Response;
using AquaAirAlert.Exception;
using AquaAirAlert.Infrastructure.Data;
using AquaAirAlert.Infrastructure.Services.LoggedUser;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AquaAirAlert.Application.UseCase.Alerts.UpdateAlerts;

public class UpdateRequestUseCase : IUpdateRequestUseCase
{
    private readonly ILoggedUser _loggedUser;
    private readonly AppDbContext  _appDbContext;
    private readonly IMapper _mapper;
    public UpdateRequestUseCase(ILoggedUser  loggedUser, AppDbContext appDbContext, IMapper mapper)
    {
        _loggedUser = loggedUser;
        _appDbContext = appDbContext;
        _mapper = mapper;
    }
    public async Task<ResponseAlert> Execute(long id, AlertRequest request)
    {
        
        await Validate(request);
        
        var loggedUser = await _loggedUser.Get();
        
        var entity = await _appDbContext.Alerts.FirstOrDefaultAsync(alert => alert.Id == id && alert.UserId == loggedUser.Id);
        
        if (entity is null)
        {
            return null;
        }
        
        _mapper.Map(request, entity);
        
        _appDbContext.Alerts.Update(entity);
        await _appDbContext.SaveChangesAsync();

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