using AquaAirAlert.Communication.Request;
using AquaAirAlert.Communication.Response;

namespace AquaAirAlert.Application.UseCase.RegisterAlerts;

public interface IRegisterAlertsUSeCase
{
    public Task<ResponseAlert> Execute(AlertRequest request);
}