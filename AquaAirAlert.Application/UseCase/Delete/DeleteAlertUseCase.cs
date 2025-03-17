using AquaAirAlert.Infrastructure.Data;
using AquaAirAlert.Infrastructure.Services.LoggedUser;
using Microsoft.EntityFrameworkCore;

namespace AquaAirAlert.Application.UseCase.Delete;

public class DeleteAlertUseCase : IDeleteAlertUseCase
{
    private readonly ILoggedUser _loggedUser;

    public DeleteAlertUseCase(ILoggedUser  loggedUser)
    {
        _loggedUser = loggedUser;   
    }
    
    public async Task<bool> Delete(long id)
    {
        var dbcontext = new AppDbContext();
        
        var loggedUser = await _loggedUser.Get();
        
        var entity = await dbcontext.Alerts.FirstOrDefaultAsync(alert => alert.Id == id && alert.UserId == loggedUser.Id);

        if (entity is null)
        {
            return false;
        }
        
        dbcontext.Alerts.Remove(entity);
        await dbcontext.SaveChangesAsync();  
        return true;
    }
}