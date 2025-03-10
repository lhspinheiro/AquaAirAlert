using AquaAirAlert.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AquaAirAlert.Application.UseCase.Delete;

public class DeleteAlertUseCase
{
    
    private readonly AppDbContext _dbContext;

    public DeleteAlertUseCase(AppDbContext  dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<bool> Delete(long id)
    {
        var entity = await _dbContext.Alerts.FirstOrDefaultAsync(d => d.Id == id);

        if (entity is null)
        {
            return false;
        }
        
        _dbContext.Alerts.Remove(entity);
        await _dbContext.SaveChangesAsync();  
        return true;
    }
}