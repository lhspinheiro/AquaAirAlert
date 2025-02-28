using AquaAirAlert.Communication.Request;
using AquaAirAlert.Communication.Response;
using AquaAirAlert.Exception;
using AquaAirAlert.Infrastructure.Data;

namespace AquaAirAlert.Application.UseCase.RegisterAlerts;

public class RegisterAlertsUSeCase
{
    public async Task<ResponseAlert> Execute(AlertRequest request)
    {
        var dbContext = new AppDbContext();
        
        await Validate(request);
        

        var entity = new alert()
        {
            Localizacao = request.Localizacao,
            Data = request.Data,
            Descricao = request.Descricao,
        };
        
        await dbContext.Alerts.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        
        return new ResponseAlert
        {   
            Localizacao = entity.Localizacao,
            Data = entity.Data,
            Descricao = entity.Descricao,
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