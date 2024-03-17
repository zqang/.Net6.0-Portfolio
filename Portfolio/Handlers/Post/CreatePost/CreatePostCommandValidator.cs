using FluentValidation;

namespace PortfolioAPI.Handlers.Post.CreatePost
{
    public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator() 
        { 
            this.RuleFor(c => c.AuthorId).NotEmpty()
                .WithMessage("Author ID cannot be empty");

            this.RuleFor(c => c.Title).NotEmpty()
                .WithMessage("Title cannot be empty");

            this.RuleFor(c => c.Content).NotEmpty()
                .WithMessage("Content cannot be empty");

            this.RuleFor(command => command.TagIds)
                .NotEmpty().WithMessage("At least one tag ID is required.")
                .When(command => command.TagIds != null && command.TagIds.Any()) // Validate only if provided
                .Must(HaveUniqueIds).WithMessage("Duplicate tag IDs are not allowed.");
        }

        private bool HaveUniqueIds(IEnumerable<Guid> tagIds)
        {
            return tagIds.Distinct().Count() == tagIds.Count();
        }
    }
}
