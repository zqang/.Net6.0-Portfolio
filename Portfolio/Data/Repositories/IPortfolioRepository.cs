using PortfolioAPI.Models;

namespace PortfolioAPI.Data.Repositories
{
    public interface IPortfolioRepository
    {
        public Task<Portfolio> GetByIdAsync(int id);

        public Task<List<Portfolio>> GetAllAsync();

        public Task AddAsync(Portfolio Portfolio);

        public Task UpdateAsync(Portfolio Portfolio);

        public Task DeleteAsync(int id);
    }
}