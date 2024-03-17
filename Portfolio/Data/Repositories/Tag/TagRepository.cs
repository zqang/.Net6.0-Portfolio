using Microsoft.EntityFrameworkCore;
using TagModel = PortfolioAPI.Models.Tag;

namespace PortfolioAPI.Data.Repositories.Tag
{
    public class TagRepository : ITagRepository
    {
        private readonly PortfolioDbContext _context;

        public TagRepository(PortfolioDbContext context)
        {
            _context = context;
        }

        public async Task<List<TagModel>> GetAllAsync()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task<TagModel?> GetByIdAsync(Guid tagId)
        {
            return await _context.Tags.FindAsync(tagId);
        }

        public async Task<List<TagModel>> GetByPostIdAsync(Guid postId)
        {
            return await _context.Tags
                .Where(t => t.Posts.Any(p => p.PostID == postId))
                .ToListAsync();
        }

        public async Task<ICollection<TagModel>> GetByIdsAsync(IEnumerable<Guid> tagIds, CancellationToken cancellationToken)
        {
            // Use EF Core to retrieve tags by ID
            var tags = await _context.Tags.Where(t => tagIds.Contains(t.TagID)).ToListAsync(cancellationToken);
            return tags;
        }

        public async Task<TagModel?> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await _context.Tags.FirstOrDefaultAsync(t => t.Name == name, cancellationToken: cancellationToken);
        }

        public async Task DeleteAsync(Guid tagId)
        {
            var tag = await _context.Tags.FindAsync(tagId);
            if (tag != null)
            {
                _context.Tags.Remove(tag);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(TagModel tag)
        {
            _context.Entry(tag).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task AddAsync(TagModel tag)
        {
            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();
        }
    }
}
