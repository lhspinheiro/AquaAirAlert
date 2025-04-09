using AquaAirAlert.Communication.Response;
using AquaAirAlert.Infrastructure.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AquaAirAlert.Application.UseCase.Alerts.GetAlertsByLocation;

public class GetByLocationUseCase : IGetByLocationUseCase
{
    private readonly AppDbContext  _dbContext;
    private readonly IMapper _mapper;

    public GetByLocationUseCase(AppDbContext  dbContext, IMapper mapper)
    {
     _dbContext = dbContext;   
     _mapper = mapper;
    }
    
    public async Task<List<ResponseAlert>> Execute(string location)
    {
        
        
        var response = await _dbContext.Alerts
            .OrderByDescending(d => d.Data)
            .Where(l => EF.Functions.Collate(l.Localizacao, "NOCASE") == location).ToListAsync();
        
        return _mapper.Map<List<ResponseAlert>>(response);
    }
}