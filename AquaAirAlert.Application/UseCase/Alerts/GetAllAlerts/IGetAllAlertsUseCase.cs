using AquaAirAlert.Communication.Response;

namespace AquaAirAlert.Application.UseCase.Alerts.GetAllAlerts;

public interface IGetAllAlertsUseCase
{
    public Task  <List<ResponseAlert>>Execute();
}