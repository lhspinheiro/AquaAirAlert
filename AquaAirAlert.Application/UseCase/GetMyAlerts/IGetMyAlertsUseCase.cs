using AquaAirAlert.Communication.Response;

namespace AquaAirAlert.Application.UseCase.GetMyAlerts;

public interface IGetMyAlertsUseCase
{
    Task<List<ResponseAlert>> GetMyAlerts();
}