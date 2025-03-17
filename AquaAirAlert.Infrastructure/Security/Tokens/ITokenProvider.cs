using AquaAirAlert.Infrastructure.Data;

namespace AquaAirAlert.Infrastructure.Security.Tokens;

public interface ITokenProvider
{
    string tokenOnRequest();
}