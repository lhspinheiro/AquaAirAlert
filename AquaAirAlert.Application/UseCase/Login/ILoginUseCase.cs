using AquaAirAlert.Communication.Request;
using AquaAirAlert.Communication.Response;

namespace AquaAirAlert.Application.UseCase.Login;

public interface ILoginUseCase
{
    public Task<ResponseSuccessLogin> Login(RequestLogin request);
}