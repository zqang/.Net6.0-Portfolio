using MediatR;
using PortfolioAPI.BuildingBlocks.Commands;

namespace PortfolioAPI.Handlers.Post.UpdatePost
{
    public class UpdatePostCommand : CommandBase
    {
        public UpdatePostCommand(Guid id, string title, string content, string videosURL,
            string status, bool featured, string featuredImageURL, List<Guid> tagIds) : base(id)
        {
            Title = title;
            Content = content;
            VideosURL = videosURL;
            Status = status;
            Featured = featured;
            TagIds = tagIds;
            FeaturedImageURL = featuredImageURL;
        }
        public string Title { get; }
        public string Content { get; }
        public string VideosURL { get; }
        public string Status { get; }
        public bool Featured { get; }
        public string FeaturedImageURL { get; }
        public List<Guid> TagIds { get; }
    }
}
