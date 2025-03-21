using AquaAirAlert.Communication.Request;
using AquaAirAlert.Communication.Response;

namespace AquaAirAlert.Application.UseCase.Users.Login;

public interface ILoginUseCase
{
    public Task<ResponseSuccessLogin> Login(RequestLogin request);
}