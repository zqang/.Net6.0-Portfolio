using PortfolioAPI.Models;

namespace PortfolioAPI.Repositories
{
    public interface IBlogPostRepository
    {
        public Task<BlogPost> GetByIdAsync(int id);

        public Task<List<BlogPost>> GetAllAsync();

        public Task AddAsync(BlogPost blogPost);

        public Task UpdateAsync(BlogPost blogPost);

        public Task DeleteAsync(int id);
    }
}