using MediatR;
using PortfolioAPI.Dtos;

namespace PortfolioAPI.CommandsQueries
{

    public class GetBlogPostsQuery : IRequest<List<BlogPostDto>> { }

    public class GetBlogPostQuery : IRequest<BlogPostDto>
    {
        public int Id { get; set; }
    }

    public class CreateBlogPostCommand : IRequest<BlogPostDto>
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }

    public class DeleteBlogPostCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }

    public class UpdateBlogPostCommand : IRequest<BlogPostDto>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }

}
