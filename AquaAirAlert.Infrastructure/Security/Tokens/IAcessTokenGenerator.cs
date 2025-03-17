using AquaAirAlert.Infrastructure.Data;

namespace AquaAirAlert.Infrastructure.Security.Tokens;

public interface IAcessTokenGenerator
{
    string Generate(User user);
}