using UserModel = PortfolioAPI.Models.User;

namespace PortfolioAPI.Data.Repositories.User
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllAsync();
        Task<UserModel?> GetByIdAsync(Guid userId);
        Task<UserModel?> GetByEmailAsync(string email);
        Task DeleteAsync(Guid userId);
        Task UpdateAsync(UserModel user);
        Task AddAsync(UserModel user);
    }
}
