using System.Net;
using AquaAirAlert.Application.UseCase.RegisterAlerts;
using AquaAirAlert.Communication.Request;
using AquaAirAlert.Communication.Response;
using AquaAirAlert.Exception;
using AquaAirAlert.Infrastructure.Data;
using AquaAirAlert.Infrastructure.Services.LoggedUser;
using Microsoft.EntityFrameworkCore;

namespace AquaAirAlert.Application.UseCase.UpdateAlerts;

public class UpdateRequestUseCase : IUpdateRequestUseCase
{
    private readonly ILoggedUser _loggedUser;
    public UpdateRequestUseCase(ILoggedUser  loggedUser)
    {
        _loggedUser = loggedUser;
    }
    public async Task<ResponseAlert> Execute(long id, AlertRequest request)
    {
        var dbcontext = new AppDbContext();
        
        await Validate(request);
        
        var loggedUser = await _loggedUser.Get();
        
        var entity = await dbcontext.Alerts.FirstOrDefaultAsync(alert => alert.Id == id && alert.UserId == loggedUser.Id);
        
        if (entity is null)
        {
            return null;
        }
        
        entity.Localizacao = request.Localizacao;
        entity.Data = request.Data;
        entity.Descricao = request.Descricao;
        
        dbcontext.Alerts.Update(entity);
        await dbcontext.SaveChangesAsync();

        return new ResponseAlert
        {
            Id = entity.Id,
            Localizacao = entity.Localizacao,
            Data = entity.Data,
            Descricao = entity.Descricao,
            UserId = entity.UserId,
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