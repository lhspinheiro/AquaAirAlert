using AquaAirAlert.Communication.Request;
using AquaAirAlert.Communication.Response;
using AquaAirAlert.Exception;
using AquaAirAlert.Infrastructure.Data;
using AquaAirAlert.Infrastructure.Services.LoggedUser;

namespace AquaAirAlert.Application.UseCase.RegisterAlerts;

public class RegisterAlertsUSeCase : IRegisterAlertsUSeCase
{
    private readonly ILoggedUser _loggedUser;

    public RegisterAlertsUSeCase(ILoggedUser  loggedUser)
    {
        _loggedUser = loggedUser;
    }
    
    public async Task<ResponseAlert> Execute(AlertRequest request)
    {
        var dbContext = new AppDbContext();
        
        await Validate(request);

        var loggedUser = await _loggedUser.Get();
        
        var entity = new alert()
        {
            Localizacao = request.Localizacao,
            Data = request.Data,
            Descricao = request.Descricao,
            UserId = loggedUser.Id,
        };
        
        await dbContext.Alerts.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        
        return new ResponseAlert
        {   
            Id = entity.Id,
            Localizacao = entity.Localizacao,
            Data = entity.Data,
            Descricao = entity.Descricao,
            UserId = entity.UserId
        };
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