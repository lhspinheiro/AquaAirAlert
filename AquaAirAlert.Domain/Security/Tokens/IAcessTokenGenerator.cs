using AquaAirAlert.Infrastructure.Data;

namespace AquaAirAlert.Domain.Security.Tokens;

public interface IAcessTokenGenerator
{
    string Generate(User user);
}