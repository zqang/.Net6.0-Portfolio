using PortfolioAPI.BuildingBlocks.Commands;

namespace PortfolioAPI.Handlers.Author.CreateAuthor
{
    public class CreateAuthorCommand : CommandBase<Guid>
    {
        public CreateAuthorCommand(Guid userID, string name, string bio) 
        { 
            UserID = userID;
            Name = name;
            Bio = bio;
        }

        public Guid UserID { get; } 
        public string Name { get; }
        public string Bio {  get; }
    }
}
