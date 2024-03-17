using FluentValidation;

namespace PortfolioAPI.Handlers.Post.DeletePost
{
    public class DeletePostCommandValidator : AbstractValidator<DeletePostCommand>
    {
        public DeletePostCommandValidator() 
        {
            this.RuleFor(c => c.Id).NotEmpty().WithMessage("Post ID cannot be empty");
        }
    }
}
