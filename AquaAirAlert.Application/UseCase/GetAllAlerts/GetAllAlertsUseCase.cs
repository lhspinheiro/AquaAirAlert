using AquaAirAlert.Communication.Response;
using AquaAirAlert.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AquaAirAlert.Application.UseCase.GetAllAlerts;

public class GetAllAlertsUseCase : IGetAllAlertsUseCase
{

    private readonly AppDbContext  _dbContext;

    public GetAllAlertsUseCase(AppDbContext  dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task <List<ResponseAlert>> Execute()
    {
         var response = await _dbContext.Alerts.AsNoTracking().OrderByDescending(order => order.Data).Select(r => new ResponseAlert
         {
             Id = r.Id,
             Localizacao = r.Localizacao,
             Data=r.Data,
             Descricao = r.Descricao,
             UserId = r.UserId
         }).ToListAsync(); 
         
        return response; 
    }
}