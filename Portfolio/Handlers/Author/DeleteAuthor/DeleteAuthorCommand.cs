using PortfolioAPI.BuildingBlocks.Commands;

namespace PortfolioAPI.Handlers.Author.DeleteAuthor
{
    public class DeleteAuthorCommand : CommandBase
    {
        public DeleteAuthorCommand(Guid id): base(id) { }
    }
}
