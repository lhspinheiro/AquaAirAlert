using AquaAirAlert.Communication.Response;
using AquaAirAlert.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AquaAirAlert.Application.UseCase.Alerts.GetAlertsByLocation;

public class GetByLocationUseCase : IGetByLocationUseCase
{
    private readonly AppDbContext  _dbContext;

    public GetByLocationUseCase(AppDbContext  dbContext)
    {
     _dbContext = dbContext;   
    }
    
    public async Task<List<ResponseAlert>> Execute(string location)
    {
        var response = await _dbContext.Alerts.OrderByDescending(d => d.Data)
            .Where(l => EF.Functions.Collate(l.Localizacao, "NOCASE") == location).Select(r => new ResponseAlert
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