using System.Net;

namespace AquaAirAlert.Exception;

public class InvalidLoginException : AlertsException
{
    public override List<string> GetErrorMessages() => ["Email or password is incorrect."];

    public override HttpStatusCode GetStatusCode() => HttpStatusCode.Unauthorized;
}