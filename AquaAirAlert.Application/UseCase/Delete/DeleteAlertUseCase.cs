using AquaAirAlert.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AquaAirAlert.Application.UseCase.Delete;

public class DeleteAlertUseCase : IDeleteAlertUseCase
{
    public async Task<bool> Delete(long id)
    {
        var dbcontext = new AppDbContext();
        
        
        var entity = await dbcontext.Alerts.FirstOrDefaultAsync(d => d.Id == id);

        if (entity is null)
        {
            return false;
        }
        
        dbcontext.Alerts.Remove(entity);
        await dbcontext.SaveChangesAsync();  
        return true;
    }
}