using Application.Dtos.Game;
using FluentValidation;

namespace Application.Validators.Game
{
    internal class CreateGameDtoValidator : AbstractValidator<CreateGameDto>
    {
        public CreateGameDtoValidator()
        {
            RuleFor(e => e.Name).NotEmpty().MaximumLength(64).WithMessage("Name is empty or too long");
            RuleFor(e => e.Description).NotEmpty().MaximumLength(512).WithMessage("Description is empty or too long");
        }
    }
}
