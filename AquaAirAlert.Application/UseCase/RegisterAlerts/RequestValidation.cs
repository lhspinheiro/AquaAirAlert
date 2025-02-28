using AquaAirAlert.Communication.Request;
using FluentValidation;

namespace AquaAirAlert.Application.UseCase.RegisterAlerts;

public class RequestValidation : AbstractValidator<AlertRequest>
{
    public RequestValidation()
    {
        RuleFor(request => request.Localizacao).NotEmpty().WithMessage("Localização é obrigatporia!");
        RuleFor(request => request.Data).LessThanOrEqualTo(DateTime.Now)
            .WithMessage("Data não pode ser para o futuro");
        RuleFor(request => request.Descricao.Length).GreaterThanOrEqualTo(20).WithMessage("A descrição deve ter pelo menos 20 caracteres. Por favor, forneça uma descrição completa e detalhada do ocorrido");
    }
}