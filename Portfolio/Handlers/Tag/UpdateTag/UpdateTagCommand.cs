using PortfolioAPI.BuildingBlocks.Commands;

namespace PortfolioAPI.Handlers.Tag.UpdateTag
{
    public class UpdateTagCommand : CommandBase
    {
        public UpdateTagCommand(string name, string description) 
        {
            Name = name;
            Description = description;
        }
        public string Name { get; }
        public string Description { get; }
    }
}
