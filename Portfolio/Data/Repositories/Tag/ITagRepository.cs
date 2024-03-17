using TagModel = PortfolioAPI.Models.Tag;

namespace PortfolioAPI.Data.Repositories.Tag
{
    public interface ITagRepository
    {
        Task<List<TagModel>> GetAllAsync();
        Task<TagModel?> GetByIdAsync(Guid tagId);
        Task<ICollection<TagModel>> GetByIdsAsync(IEnumerable<Guid> tagIds, CancellationToken cancellationToken);
        Task<List<TagModel>> GetByPostIdAsync(Guid postId);
        Task<TagModel?> GetByNameAsync(string name, CancellationToken cancellationToken);
        Task DeleteAsync(Guid tagId);
        Task UpdateAsync(TagModel tag);
        Task AddAsync(TagModel tag);
    }
}
