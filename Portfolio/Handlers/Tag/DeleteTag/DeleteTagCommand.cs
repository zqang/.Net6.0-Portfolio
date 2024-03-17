using PortfolioAPI.BuildingBlocks.Commands;

namespace PortfolioAPI.Handlers.Tag.DeleteTag
{
    public class DeleteTagCommand : CommandBase
    {
        public DeleteTagCommand(Guid id) : base(id) { }
    }
}
