using PortfolioAPI.BuildingBlocks.Commands;
using PortfolioAPI.Data.Repositories.Tag;

namespace PortfolioAPI.Handlers.Tag.UpdateTag
{
    public class UpdateTagCommandHandler : ICommandHandler<UpdateTagCommand>
    {
        private readonly ITagRepository _tagRepository;
        
        public UpdateTagCommandHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            var existingTag = await _tagRepository.GetByIdAsync(request.Id);

            if (existingTag == null)
            {
                throw new ArgumentException($"Tag with ID {request.Id} not found.");
            }

            existingTag.Name = request.Name;
            existingTag.Description = request.Description;

            await _tagRepository.UpdateAsync(existingTag);
        }
    }
}
