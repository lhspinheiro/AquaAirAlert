using AquaAirAlert.Communication.Response;
using AquaAirAlert.Exception;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AquaAirAlert.Api.FIlters;

public class ExceptionFIlter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is AlertsException alertsException)
        {
            context.HttpContext.Response.StatusCode = (int)alertsException.GetStatusCode();
            context.Result = new ObjectResult(new ResponseErrorMessagesJson
            {
                Errors = alertsException.GetErrorMessages()
            });
        }

        else
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorMessagesJson
            {
                Errors = ["Unknown error"]
            });
        }
    }
}