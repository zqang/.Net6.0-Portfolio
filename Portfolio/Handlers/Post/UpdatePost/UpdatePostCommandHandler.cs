using MediatR;
using PortfolioAPI.BuildingBlocks.Commands;
using PortfolioAPI.Data.Repositories.Post;
using PortfolioAPI.Data.Repositories.Tag;

namespace PortfolioAPI.Handlers.Post.UpdatePost
{
    public class UpdatePostCommandHandler : ICommandHandler<UpdatePostCommand>
    {
        private readonly IPostRepository _postRepository;
        private readonly ITagRepository _tagRepository;

        public UpdatePostCommandHandler(IPostRepository postRepository, ITagRepository tagRepository)
        {
            _postRepository = postRepository;
            _tagRepository = tagRepository;
        }

        public async Task Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            // 1. Fetch the existing Post by ID
            var existingPost = await _postRepository.GetByIdAsync(request.Id);

            if (existingPost == null)
            {
                throw new ArgumentException($"Post with ID {request.Id} not found.");
            }

            // 2. Update Post properties (except Tags)
            existingPost.Title = request.Title;
            existingPost.Content = request.Content;
            existingPost.VideoURL = request.VideosURL;
            existingPost.LastModifiedDate = DateTime.Now;
            existingPost.Status = request.Status;
            existingPost.Featured = request.Featured;
            existingPost.FeaturedImageURL = request.FeaturedImageURL;

            // 3. Handle Tag Updates (optional)
            if (request.TagIds != null)
            {
                // 3.1. Find all requested Tags by their IDs
                var newTags = await _tagRepository.GetByIdsAsync(request.TagIds.ToList(), cancellationToken);

                // 3.2. Validate if all requested Tags exist (optional)
                if (newTags.Count != request.TagIds.Count)
                {
                    throw new ArgumentException("One or more specified tag IDs were not found.");
                }

                // 3.3. Update the Post's Tags association (clear existing, add new)
                existingPost.UpdateTags(newTags);
            }

            // 4. Save the updated Post
            await _postRepository.UpdateAsync(existingPost);

        }
    }
}
