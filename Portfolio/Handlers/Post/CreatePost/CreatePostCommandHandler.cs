using PortfolioAPI.BuildingBlocks.Commands;
using PortfolioAPI.Data.Repositories.Author;
using PortfolioAPI.Data.Repositories.Post;
using PortfolioAPI.Data.Repositories.Tag;

namespace PortfolioAPI.Handlers.Post.CreatePost
{
    public class CreatePostCommandHandler : ICommandHandler<CreatePostCommand, Guid>
    {
        private readonly IPostRepository _postRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly ITagRepository _tagRepository;

        public CreatePostCommandHandler(IPostRepository postRepository, IAuthorRepository authorRepository, ITagRepository tagRepository)
        {
            _postRepository = postRepository;
            _authorRepository = authorRepository;
            _tagRepository = tagRepository;
        }
        public async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var post = new Models.Post
            (
                request.Id,
                request.Title,
                request.Content,
                request.VideoURL,
                request.AuthorId,
                request.Status,
                request.Featured,
                request.FeaturedImageURL
            );

            //validate and get author and tag from authorId and tagId 
            var author = await _authorRepository.GetByIdAsync(request.AuthorId);

            if (author == null)
            {
                throw new ArgumentNullException(nameof(author));
            }

            post.Author = author;

            var tags = await _tagRepository.GetByIdsAsync(request.TagIds, cancellationToken);

            if (tags.Count != request.TagIds.Count)
            {
                throw new ArgumentException("One or more specified tag IDs were not found");
            }

            post.AddTags(tags);

            await _postRepository.AddAsync(post);

            return post.PostID;
        }
    }
}
