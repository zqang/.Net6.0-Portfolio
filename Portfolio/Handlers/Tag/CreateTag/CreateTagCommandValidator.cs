using FluentValidation;

namespace PortfolioAPI.Handlers.Tag.CreateTag
{
    public class CreateTagCommandValidator : AbstractValidator<CreateTagCommand>
    {
        public CreateTagCommandValidator() 
        {
            RuleFor(command => command.Name)
            .NotEmpty().WithMessage("Tag name is required.")
            .Length(2, 50).WithMessage("Tag name must be between 2 and 50 characters.");
        }
    }
}
