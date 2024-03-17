using FluentValidation;

namespace PortfolioAPI.Handlers.Post.UpdatePost
{
    public class UpdatePostCommandValidator : AbstractValidator<UpdatePostCommand>
    {
        public UpdatePostCommandValidator()
        {
            this.RuleFor(command => command.Id)
                .NotEmpty().WithMessage("Post ID is required.");

            this.RuleFor(command => command.Title)
                .NotEmpty().WithMessage("Title is required.");
                //.Length(2, 100).WithMessage("Title must be between 2 and 100 characters.");

            this.RuleFor(command => command.Content)
                .NotEmpty().WithMessage("Content is required.");


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
