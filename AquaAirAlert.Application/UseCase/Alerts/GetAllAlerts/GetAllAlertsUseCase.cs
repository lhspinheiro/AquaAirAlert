using AquaAirAlert.Communication.Response;
using AquaAirAlert.Infrastructure.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AquaAirAlert.Application.UseCase.Alerts.GetAllAlerts;

public class GetAllAlertsUseCase : IGetAllAlertsUseCase
{

    private readonly AppDbContext  _dbContext;
    private readonly IMapper _mapper;

    public GetAllAlertsUseCase(AppDbContext  dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task <List<ResponseAlert>> Execute()
    {
         var response = await _dbContext.Alerts.AsNoTracking().OrderByDescending(order => order.Data).ToListAsync(); 
        
        return _mapper.Map<List<ResponseAlert>>(response); 
    }
}