using Application.Dtos.Topics;
using FluentValidation;

namespace Application.Validators
{
    public class CreateTopicDtoValidator 
        : AbstractValidator<CreateTopicDto>
    {
        public CreateTopicDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Заголовок обязателен")
                .MaximumLength(100)
                .WithMessage("Максимальная длина заголовка — 100 символов");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Описание обязательно")
                .MaximumLength(500)
                .WithMessage("Максимальная длина описания — 500 символов");

            RuleFor(x => x.EventStart)
               .NotEmpty().WithMessage("Описание обязательно");
        }
    }
}