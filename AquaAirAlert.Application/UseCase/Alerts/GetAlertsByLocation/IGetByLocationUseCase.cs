using AquaAirAlert.Communication.Response;

namespace AquaAirAlert.Application.UseCase.Alerts.GetAlertsByLocation;

public interface IGetByLocationUseCase
{
    Task<List<ResponseAlert>> Execute(string location);
}