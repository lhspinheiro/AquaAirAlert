using AquaAirAlert.Communication.Response;

namespace AquaAirAlert.Application.UseCase.GetAlertsByLocation;

public interface IGetByLocationUseCase
{
    Task<List<ResponseAlert>> Execute(string location);
}