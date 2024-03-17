using FluentValidation;

namespace PortfolioAPI.Handlers.Author.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator() 
        {
            this.RuleFor(c => c.UserID).NotEmpty()
                .WithMessage("User ID cannot be empty");

            this.RuleFor(c => c.Name).NotEmpty()
                .WithMessage("Name cannot be empty");
        }
    }
}
