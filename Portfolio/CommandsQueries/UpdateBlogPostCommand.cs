using MediatR;
using Portfolio.Dtos;

namespace Portfolio.CommandsQueries
{
    public class UpdateBlogPostCommand : IRequest<BlogPostDto>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }

}
