using MediatR;
using PortfolioAPI.BuildingBlocks.Commands;
using PortfolioAPI.Models;

namespace PortfolioAPI.Handlers.Post.CreatePost
{
    public class CreatePostCommand : CommandBase<Guid>
    {
        public CreatePostCommand(string title, string content, Guid authorId, List<Guid> tagIds,
            bool featured, string status, string videoURL, string featuredImageURL)
        {
            Title = title;
            Content = content;
            AuthorId = authorId;
            TagIds = tagIds;
            Featured = featured;
            Status = status;
            VideoURL = videoURL;
            FeaturedImageURL = featuredImageURL;
        }
        public string Title { get; }
        public string Content { get; }
        public Guid AuthorId { get; }
        public List<Guid> TagIds { get; }
        public bool Featured { get; }
        public string Status { get; }
        public string VideoURL { get; }
        public string FeaturedImageURL { get; }
    }
}
