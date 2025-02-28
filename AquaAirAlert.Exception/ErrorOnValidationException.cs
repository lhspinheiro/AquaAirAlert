using System.ComponentModel.DataAnnotations;
using System.Net;

namespace AquaAirAlert.Exception;

public class ErrorOnValidationException : AlertsException
{
    
    private readonly List<string> _errors;

    public ErrorOnValidationException(List<string> errorMessages)
    {
        _errors = errorMessages;
    }
        
    public override List<string> GetErrorMessages() => _errors;

    public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest;
}