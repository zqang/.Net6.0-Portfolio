namespace PortfolioAPI.Data.Repositories.Comment
{
    public interface ICommentRepository
    {
        Task<List<Models.Comment>> GetAllAsync();
        Task<Models.Comment?> GetByIdAsync(Guid commentId);
        Task<List<Models.Comment>> GetByPostIdAsync(Guid postId);
        Task DeleteAsync(Guid commentId);
        Task UpdateAsync(Models.Comment comment);
        Task AddAsync(Models.Comment comment);
    }
}
