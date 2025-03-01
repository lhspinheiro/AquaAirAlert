using AquaAirAlert.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AquaAirAlert.Application.UseCase.GetAllAlerts;

public class GetAllAlertsUseCase
{

    
    public  async Task <List<alert>> Execute()
    {
        
        var dbContext = new AppDbContext();

         var response = await dbContext.Alerts.AsNoTracking().ToListAsync(); 
        
        return response; 
        
    }
}