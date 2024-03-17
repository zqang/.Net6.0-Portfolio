using Microsoft.EntityFrameworkCore;

namespace PortfolioAPI.Data.Repositories.Author
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly PortfolioDbContext _context;

        public AuthorRepository(PortfolioDbContext context)
        {
            _context = context;
        }

        public async Task<List<Models.Author>> GetAllAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Models.Author?> GetByIdAsync(Guid authorId)
        {
            return await _context.Authors.FindAsync(authorId);
        }

        public async Task<List<Models.Author>> GetActiveAuthorsAsync()
        {
            return await _context.Authors.Where(a => a.Status == "Active").ToListAsync();
        }

        public async Task DeleteAsync(Guid authorId)
        {
            var author = await _context.Authors.FindAsync(authorId);
            if (author != null)
            {
                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Models.Author author)
        {
            _context.Entry(author).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task AddAsync(Models.Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
        }
    }
}
