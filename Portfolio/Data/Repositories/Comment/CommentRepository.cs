using Microsoft.EntityFrameworkCore;
using CommentModel = PortfolioAPI.Models.Comment;

namespace PortfolioAPI.Data.Repositories.Comment
{
    public class CommentRepository : ICommentRepository
    {
        private readonly PortfolioDbContext _context;

        public CommentRepository(PortfolioDbContext context)
        {
            _context = context;
        }

        public async Task<List<CommentModel>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<CommentModel?> GetByIdAsync(Guid commentId)
        {
            return await _context.Comments.FindAsync(commentId);
        }

        public async Task<List<CommentModel>> GetByPostIdAsync(Guid postId)
        {
            return await _context.Comments.Where(c => c.PostID == postId).ToListAsync();
        }

        public async Task DeleteAsync(Guid commentId)
        {
            var comment = await _context.Comments.FindAsync(commentId);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(CommentModel comment)
        {
            _context.Entry(comment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task AddAsync(CommentModel comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }
    }
}
