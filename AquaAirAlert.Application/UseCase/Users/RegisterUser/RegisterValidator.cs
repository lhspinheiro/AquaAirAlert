using AquaAirAlert.Communication.Request;
using FluentValidation;

namespace AquaAirAlert.Application.UseCase.Users.RegisterUser;

public class RegisterValidator : AbstractValidator<UserRequest>
{
    public RegisterValidator()
    {
        RuleFor(  register => register.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(  register => register.Email).EmailAddress().WithMessage("Name is invalid.");
        RuleFor(register => register.Password).NotEmpty().WithMessage("Password is required");
        When(register => string.IsNullOrEmpty(register.Password) == false, () =>
        {
            RuleFor(request => request.Password.Length).GreaterThanOrEqualTo(6).WithMessage("Password must be at least 6 characters");
        });
    }
}