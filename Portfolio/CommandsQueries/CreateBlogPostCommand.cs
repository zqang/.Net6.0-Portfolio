using MediatR;
using Portfolio.Dtos;

namespace Portfolio.CommandsQueries
{
    public class CreateBlogPostCommand : IRequest<BlogPostDto>
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }

    

}
