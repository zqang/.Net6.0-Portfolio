using MediatR;
using Portfolio.Dtos;

namespace Portfolio.CommandsQueries
{
    public class DeleteBlogPostCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }

}
