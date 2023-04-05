using MediatR;
using Portfolio.Dtos;

namespace Portfolio.CommandsQueries
{
    public class GetBlogPostQuery : IRequest<BlogPostDto>
    {
        public int Id { get; set; }
    }

}
