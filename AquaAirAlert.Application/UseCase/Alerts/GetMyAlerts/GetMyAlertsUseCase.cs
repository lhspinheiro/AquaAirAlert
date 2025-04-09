using AquaAirAlert.Communication.Response;
using AquaAirAlert.Infrastructure.Data;
using AquaAirAlert.Infrastructure.Services.LoggedUser;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AquaAirAlert.Application.UseCase.Alerts.GetMyAlerts;

public class GetMyAlertsUseCase :  IGetMyAlertsUseCase
{
    private readonly ILoggedUser  _loggedUser;
    private readonly AppDbContext  _dbContext;
    private readonly IMapper _mapper;

    public GetMyAlertsUseCase(ILoggedUser  loggedUser, AppDbContext dbContext, IMapper mapper)
    {
        _loggedUser = loggedUser;
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<List<ResponseAlert>> GetMyAlerts()
    {
        var loggedUser = await _loggedUser.Get();
        
        var response = await _dbContext.Alerts.AsNoTracking()
            .OrderByDescending(d => d.Data)
            .Where(u => u.UserId == loggedUser.Id)
            .ToListAsync(); 
        
        return _mapper.Map<List<ResponseAlert>>(response);
    }
}