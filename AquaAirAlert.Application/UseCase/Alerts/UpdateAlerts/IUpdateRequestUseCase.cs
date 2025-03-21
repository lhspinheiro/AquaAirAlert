using AquaAirAlert.Communication.Request;
using AquaAirAlert.Communication.Response;

namespace AquaAirAlert.Application.UseCase.Alerts.UpdateAlerts;

public interface IUpdateRequestUseCase
{
    public Task<ResponseAlert> Execute(long id, AlertRequest request);
}