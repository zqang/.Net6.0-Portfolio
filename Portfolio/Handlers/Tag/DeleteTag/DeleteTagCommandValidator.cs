using FluentValidation;

namespace PortfolioAPI.Handlers.Tag.DeleteTag
{
    public class DeleteTagCommandValidator : AbstractValidator<DeleteTagCommand>
    {
        public DeleteTagCommandValidator() 
        {
            this.RuleFor(command => command.Id)
                .NotEmpty()
                .WithMessage("Tag ID cannot be empty");
        }
    }
}
