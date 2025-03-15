using AquaAirAlert.Communication.Request;
using AquaAirAlert.Communication.Response;

namespace AquaAirAlert.Application.UseCase.GetAllAlerts;

public interface IGetAllAlertsUseCase
{
    public Task  <List<ResponseAlert>>Execute();
}