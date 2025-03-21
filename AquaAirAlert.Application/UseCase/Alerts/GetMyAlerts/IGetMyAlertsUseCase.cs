using AquaAirAlert.Communication.Response;

namespace AquaAirAlert.Application.UseCase.Alerts.GetMyAlerts;

public interface IGetMyAlertsUseCase
{
    Task<List<ResponseAlert>> GetMyAlerts();
}