using MediatR;
using Portfolio.Dtos;

namespace Portfolio.CommandsQueries
{
    public class DeleteBlogPostCommand : IRequest
    {
        public int Id { get; set; }
    }

}
