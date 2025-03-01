namespace Application.Validators
{
    public class RegisterUserDtoValidator 
        : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator()
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