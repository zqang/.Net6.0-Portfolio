using PortfolioAPI.BuildingBlocks.Commands;
using PortfolioAPI.Data.Repositories.Author;

namespace PortfolioAPI.Handlers.Author.DeleteAuthor
{
    public class DeleteAuthorCommandHandler : ICommandHandler<DeleteAuthorCommand>
    {
        private IAuthorRepository _authorRepository;
        public async Task Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetByIdAsync(request.Id);
            if (author == null)
            {
                throw new ArgumentNullException($"Author with ID {request.Id} not found.");
            }

            await _authorRepository.DeleteAsync(author.AuthorID);
        }
    }
}
