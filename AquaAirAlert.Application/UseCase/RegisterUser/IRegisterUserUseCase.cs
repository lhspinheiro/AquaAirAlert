using AquaAirAlert.Communication.Request;
using AquaAirAlert.Communication.Response;

namespace AquaAirAlert.Application.UseCase.RegisterUser;

public interface IRegisterUserUseCase
{
    public Task<ResponseUserRegistered>  Execute(UserRequest  request);
}