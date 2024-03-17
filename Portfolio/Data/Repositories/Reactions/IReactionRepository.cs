using PortfolioAPI.Models;

namespace PortfolioAPI.Data.Repositories.Reactions
{
    public interface IReactionRepository
    {
        Task<List<Reaction>> GetAllAsync();
        Task<Reaction?> GetByIdAsync(Guid reactionId);
        Task<List<Reaction>> GetByPostIdAsync(Guid postId);
        Task DeleteAsync(Guid reactionId);
        Task UpdateAsync(Reaction reaction);
        Task AddAsync(Reaction reaction);
    }
}
