using Microsoft.EntityFrameworkCore;
using PortfolioAPI.Models;

namespace PortfolioAPI.Data.Repositories.Reactions
{
    public class ReactionRepository : IReactionRepository
    {
        private readonly PortfolioDbContext _context;

        public ReactionRepository(PortfolioDbContext context)
        {
            _context = context;
        }

        public async Task<List<Reaction>> GetAllAsync()
        {
            return await _context.Reactions.ToListAsync();
        }

        public async Task<Reaction?> GetByIdAsync(Guid reactionId)
        {
            return await _context.Reactions.FindAsync(reactionId);
        }

        public async Task<List<Reaction>> GetByPostIdAsync(Guid postId)
        {
            return await _context.Reactions.Where(ld => ld.PostID == postId).ToListAsync();
        }

        public async Task DeleteAsync(Guid reactionId)
        {
            var reaction = await _context.Reactions.FindAsync(reactionId);
            if (reaction != null)
            {
                _context.Reactions.Remove(reaction);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Reaction reaction)
        {
            _context.Entry(reaction).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task AddAsync(Reaction reaction)
        {
            _context.Reactions.Add(reaction);
            await _context.SaveChangesAsync();
        }
    }
}
