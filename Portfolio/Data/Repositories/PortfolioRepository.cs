using Microsoft.EntityFrameworkCore;
using PortfolioAPI.Data;
using PortfolioAPI.Models;

namespace PortfolioAPI.Data.Repositories
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly PortfolioDbContext _dbContext;

        public PortfolioRepository(PortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Portfolio> GetByIdAsync(int id)
        {
            return await _dbContext.Portfolios.FindAsync(id);
        }

        public async Task<List<Portfolio>> GetAllAsync()
        {
            return await _dbContext.Portfolios.ToListAsync();
        }

        public async Task AddAsync(Portfolio Portfolio)
        {
            await _dbContext.Portfolios.AddAsync(Portfolio);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Portfolio Portfolio)
        {
            _dbContext.Entry(Portfolio).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Portfolio = await GetByIdAsync(id);
            _dbContext.Portfolios.Remove(Portfolio);
            await _dbContext.SaveChangesAsync();
        }
    }
}
