using PostModel =  PortfolioAPI.Models.Post;

namespace PortfolioAPI.Data.Repositories.Post
{
    public interface IPostRepository
    {
        public Task<PostModel?> GetByIdAsync(int id);
        public Task<PostModel?> GetByAuthorIdAsync(int authorId);
        public Task<List<PostModel>> GetByTagIdAsync(int tagId);

        public Task<List<PostModel>> GetAllAsync();

        public Task AddAsync(PostModel post);

        public Task UpdateAsync(PostModel post);

        public Task DeleteAsync(int id);
    }
}
