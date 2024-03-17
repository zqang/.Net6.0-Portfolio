using Microsoft.EntityFrameworkCore;

namespace PortfolioAPI.Data.Repositories.Author
{
    public interface IAuthorRepository
    {
        Task<List<Models.Author>> GetAllAsync();
        Task<Models.Author?> GetByIdAsync(Guid authorId);
        Task<List<Models.Author>> GetActiveAuthorsAsync();
        Task DeleteAsync(Guid authorId);
        Task UpdateAsync(Models.Author author);
        Task AddAsync(Models.Author author);
    }
}

