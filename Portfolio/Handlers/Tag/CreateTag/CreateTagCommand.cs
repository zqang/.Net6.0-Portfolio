using PortfolioAPI.BuildingBlocks.Commands;

namespace PortfolioAPI.Handlers.Tag.CreateTag
{
    public class CreateTagCommand : CommandBase<Guid>
    {
        public CreateTagCommand(string name, string description) 
        { 
            Name = name;
            Description = description;
        }

        public string Name { get; }
        public string Description { get; }
    }
}
