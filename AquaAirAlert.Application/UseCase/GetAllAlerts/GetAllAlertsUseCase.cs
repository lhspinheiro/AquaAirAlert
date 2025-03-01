using AquaAirAlert.Communication.Response;
using AquaAirAlert.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AquaAirAlert.Application.UseCase.GetAllAlerts;

public class GetAllAlertsUseCase
{

    private readonly AppDbContext  _dbContext;

    public GetAllAlertsUseCase(AppDbContext  dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task <List<ResponseAlert>> Execute()
    {
         var response = await _dbContext.Alerts.AsNoTracking().Select(r => new ResponseAlert
         {
             Localizacao = r.Localizacao,
             Data=r.Data,
             Descricao = r.Descricao,
         }).ToListAsync(); 
        
        return response; 
        
    }
}