using AquaAirAlert.Infrastructure.Data;

namespace AquaAirAlert.Infrastructure.Services.LoggedUser;

public interface ILoggedUser
{
    Task<User> Get();
}