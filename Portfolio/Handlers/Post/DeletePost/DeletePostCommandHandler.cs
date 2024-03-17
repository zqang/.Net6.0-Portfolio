using MediatR;
using PortfolioAPI.BuildingBlocks.Commands;
using PortfolioAPI.Data.Repositories.Post;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PortfolioAPI.Handlers.Post.DeletePost
{
    public class DeletePostCommandHandler : ICommandHandler<DeletePostCommand>
    {
        private readonly IPostRepository _postRepository;

        public DeletePostCommandHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(request.Id);

            if (post == null)
            {
                throw new ArgumentException($"Post with ID {request.Id} not found.");
            }

            // 2. Delete the Post
            await _postRepository.DeleteAsync(post.PostID);

        }
    }
}
