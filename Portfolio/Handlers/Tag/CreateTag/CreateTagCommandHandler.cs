using PortfolioAPI.BuildingBlocks.Commands;
using PortfolioAPI.Data.Repositories.Tag;

namespace PortfolioAPI.Handlers.Tag.CreateTag
{
    public class CreateTagCommandHandler : ICommandHandler<CreateTagCommand, Guid>
    {
        private readonly ITagRepository _tagRepository;

        public CreateTagCommandHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<Guid> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            var existingTag = await _tagRepository.GetByNameAsync(request.Name, cancellationToken);
            if (existingTag != null)
            {
                throw new ArgumentException($"Tag with name '{request.Name}' already exists.");
            }

            var tag = new Models.Tag(request.Id, request.Name, request.Description);

            await _tagRepository.AddAsync(tag);

            return tag.TagID;
        }
    }
}
