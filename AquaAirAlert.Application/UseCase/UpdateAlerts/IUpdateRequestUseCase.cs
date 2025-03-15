using AquaAirAlert.Communication.Request;
using AquaAirAlert.Communication.Response;

namespace AquaAirAlert.Application.UseCase.UpdateAlerts;

public interface IUpdateRequestUseCase
{
    public Task<ResponseAlert> Execute(long id, AlertRequest request);
}