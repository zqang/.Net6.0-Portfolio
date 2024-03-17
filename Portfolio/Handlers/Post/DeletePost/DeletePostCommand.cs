using MediatR;
using PortfolioAPI.BuildingBlocks.Commands;

namespace PortfolioAPI.Handlers.Post.DeletePost
{
    public class DeletePostCommand : CommandBase
    {
        public DeletePostCommand(Guid id) : base(id) { }
    }
}
