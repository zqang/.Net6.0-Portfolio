using PostModel =  PortfolioAPI.Models.Post;

namespace PortfolioAPI.Data.Repositories.Post
{
    public interface IPostRepository
    {
        public Task<PostModel?> GetByIdAsync(Guid id);
        public Task<PostModel?> GetByAuthorIdAsync(Guid authorId);
        public Task<List<PostModel>> GetByTagIdAsync(Guid tagId);

        public Task<List<PostModel>> GetAllAsync();

        public Task AddAsync(PostModel post);

        public Task UpdateAsync(PostModel post);

        public Task DeleteAsync(Guid id);
    }
}
