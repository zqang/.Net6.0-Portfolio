using MediatR;
using PortfolioAPI.BuildingBlocks.Queries;
using PortfolioAPI.Handlers.Post.GetAllPost;
using PortfolioAPI.Models;

namespace PortfolioAPI.CommandsQueries.Post
{

    public class GetPostsQuery : IQuery<List<PostDto>>
    {
        public GetPostsQuery(Guid? categoryId, string? searchTerm, Guid? tagId, Guid? authorId, 
            int page, int pageSize) 
        {
            CategoryId = categoryId;
            SearchTerm = searchTerm;
            TagId = tagId;
            Page = page;
            PageSize = pageSize;
        }
        public Guid? CategoryId { get; } // Optional for filtering by category
        public string? SearchTerm { get; } // Optional for searching posts by title or content
        public Guid? TagId { get; }
        public Guid? AuthodId { get; }
        public int Page { get; } = 1; // Default to page 1 for pagination (optional)
        public int PageSize { get; } = 10; // Default page size (optional)
    }
}
