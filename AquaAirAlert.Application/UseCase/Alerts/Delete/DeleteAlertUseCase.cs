using AquaAirAlert.Infrastructure.Data;
using AquaAirAlert.Infrastructure.Services.LoggedUser;
using Microsoft.EntityFrameworkCore;

namespace AquaAirAlert.Application.UseCase.Alerts.Delete;

public class DeleteAlertUseCase : IDeleteAlertUseCase
{
    private readonly ILoggedUser _loggedUser;
    private readonly AppDbContext  _appDbContext;
    

    public DeleteAlertUseCase(ILoggedUser  loggedUser, AppDbContext appDbContext)
    {
        _loggedUser = loggedUser;   
        _appDbContext = appDbContext;
    }
    
    public async Task<bool> Delete(long id)
    {
        var loggedUser = await _loggedUser.Get();
        
        var entity = await _appDbContext.Alerts.FirstOrDefaultAsync(alert => alert.Id == id && alert.UserId == loggedUser.Id);

        if (entity is null)
        {
            return false;
        }
        
        _appDbContext.Alerts.Remove(entity);
        await _appDbContext.SaveChangesAsync();  
        return true;
    }
}