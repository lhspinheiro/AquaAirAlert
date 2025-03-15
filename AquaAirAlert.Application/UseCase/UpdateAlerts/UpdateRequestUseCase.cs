using System.Net;
using AquaAirAlert.Application.UseCase.RegisterAlerts;
using AquaAirAlert.Communication.Request;
using AquaAirAlert.Communication.Response;
using AquaAirAlert.Exception;
using AquaAirAlert.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AquaAirAlert.Application.UseCase.UpdateAlerts;

public class UpdateRequestUseCase : IUpdateRequestUseCase
{
    
    public async Task<ResponseAlert> Execute(long id, AlertRequest request)
    {
        var dbcontext = new AppDbContext();
        
        await Validate(request);
        
        var entity = await dbcontext.Alerts.AsNoTracking().SingleOrDefaultAsync(i => i.Id.Equals(id));
        
        if (entity == null)
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
            Descricao = entity.Descricao
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