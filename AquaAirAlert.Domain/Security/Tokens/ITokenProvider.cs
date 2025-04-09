namespace AquaAirAlert.Domain.Security.Tokens;

public interface ITokenProvider
{
    string tokenOnRequest();
}