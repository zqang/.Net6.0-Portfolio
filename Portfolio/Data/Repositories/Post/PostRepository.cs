
using Microsoft.EntityFrameworkCore;
using PortfolioAPI.Models;

namespace PortfolioAPI.Data.Repositories.Post
{
    public class PostRepository : IPostRepository
    {
        private readonly PortfolioDbContext _dbContext;

        public PostRepository(PortfolioDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<Models.Post?> GetByAuthorIdAsync(int authorId) => await _dbContext.Posts.Where(p => p.AuthorID == authorId).FirstOrDefaultAsync();

        public async Task<Models.Post?> GetByIdAsync(int id) => await _dbContext.Posts.FindAsync(id);

        public async Task<List<Models.Post>> GetByTagIdAsync(int tagId) => await _dbContext.Posts
            .Where(p => p.Tags.Any(t => t.TagID == tagId))
            .ToListAsync();

        public async Task AddAsync(Models.Post post)
        {
            _dbContext.Add(post);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var post = await GetByIdAsync(id);
            if (post != null)
            {
                _dbContext.Posts.Remove(post);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Models.Post>> GetAllAsync()
        {
            return await _dbContext.Posts.ToListAsync();
        }

        public async Task UpdateAsync(Models.Post post)
        {
            _dbContext.Entry(post).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
