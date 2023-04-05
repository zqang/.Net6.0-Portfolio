using MediatR;
using Portfolio.Dtos;

namespace Portfolio.CommandsQueries
{
    public class GetBlogPostsQuery : IRequest<List<BlogPostDto>> { }

}
