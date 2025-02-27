using Application.Dtos.Users;
using FluentValidation;

namespace Application.Validators
{
    public class LoginUserDtoValidator 
        : AbstractValidator<LoginUserDto>
    {
        public LoginUserDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email обязателен")
                .MaximumLength(100)
                .WithMessage("Максимальная длина почты — 100 символов");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Пароль обязателен")
                .MinimumLength(6)
                .WithMessage("Пароль должен быть не менее 6 символов");
        }
    }
}
