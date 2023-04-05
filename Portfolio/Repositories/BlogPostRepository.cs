using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly PortfolioDbContext _dbContext;

        public BlogPostRepository(PortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BlogPost> GetByIdAsync(int id)
        {
            return await _dbContext.BlogPosts.FindAsync(id);
        }

        public async Task<List<BlogPost>> GetAllAsync()
        {
            return await _dbContext.BlogPosts.ToListAsync();
        }

        public async Task AddAsync(BlogPost blogPost)
        {
            await _dbContext.BlogPosts.AddAsync(blogPost);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(BlogPost blogPost)
        {
            _dbContext.Entry(blogPost).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var blogPost = await GetByIdAsync(id);
            _dbContext.BlogPosts.Remove(blogPost);
            await _dbContext.SaveChangesAsync();
        }
    }
}
