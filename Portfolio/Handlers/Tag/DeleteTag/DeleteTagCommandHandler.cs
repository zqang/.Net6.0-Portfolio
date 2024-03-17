using PortfolioAPI.BuildingBlocks.Commands;
using PortfolioAPI.Data.Repositories.Tag;
using PortfolioAPI.Models;

namespace PortfolioAPI.Handlers.Tag.DeleteTag
{
    public class DeleteTagCommandHandler : ICommandHandler<DeleteTagCommand>
    {
        private readonly ITagRepository _tagRepository;

        public DeleteTagCommandHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            var existingTag = _tagRepository.GetByIdAsync(request.Id);
            if (existingTag != null)
            {
                throw new ArgumentNullException(nameof(existingTag));
            }

            await _tagRepository.DeleteAsync(request.Id);
        }
    }
}
