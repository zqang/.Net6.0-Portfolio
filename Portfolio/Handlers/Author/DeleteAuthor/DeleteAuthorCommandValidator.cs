using FluentValidation;

namespace PortfolioAPI.Handlers.Author.DeleteAuthor
{
    public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator()
        {
            this.RuleFor(c => c.Id).NotEmpty().WithMessage("Author ID cannot be empty");
        }
    }
}
