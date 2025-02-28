using System.Net;

namespace AquaAirAlert.Exception;

public abstract class AlertsException : System.Exception
{
    public abstract List<string> GetErrorMessages();
    public abstract HttpStatusCode GetStatusCode();
}