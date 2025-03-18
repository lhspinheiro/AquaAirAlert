using AquaAirAlert.Communication.Response;
using AquaAirAlert.Infrastructure.Data;
using AquaAirAlert.Infrastructure.Services.LoggedUser;
using Microsoft.EntityFrameworkCore;

namespace AquaAirAlert.Application.UseCase.GetMyAlerts;

public class GetMyAlertsUseCase :  IGetMyAlertsUseCase
{
    private readonly ILoggedUser  _loggedUser;
    private readonly AppDbContext  _dbContext;

    public GetMyAlertsUseCase(ILoggedUser  loggedUser, AppDbContext dbContext)
    {
        _loggedUser = loggedUser;
        _dbContext = dbContext;
    }
    
    
    public async Task<List<ResponseAlert>> GetMyAlerts()
    {
        var loggedUser = await _loggedUser.Get();
        
        var response = await _dbContext.Alerts.AsNoTracking()
            .OrderByDescending(d => d.Data)
            .Where(u => u.UserId == loggedUser.Id)
            .Select(r => new ResponseAlert
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