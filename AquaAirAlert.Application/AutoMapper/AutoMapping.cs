using AquaAirAlert.Communication.Request;
using AquaAirAlert.Communication.Response;
using AquaAirAlert.Domain.Entities;
using AquaAirAlert.Infrastructure.Data;
using AutoMapper;

namespace AquaAirAlert.Application.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        Request();
        Response();
    }

    private void Request()
    {
        CreateMap<AlertRequest, alert>();
        CreateMap<UserRequest, User>();
    }

    private void Response()
    {
        CreateMap<alert, ResponseAlert>();
        CreateMap<User, ResponseUserRegistered>();
    }
}