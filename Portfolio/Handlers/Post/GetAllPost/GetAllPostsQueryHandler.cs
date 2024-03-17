using Dapper;
using MediatR;
using PortfolioAPI.BuildingBlocks;
using PortfolioAPI.BuildingBlocks.Queries;
using PortfolioAPI.Models;

namespace PortfolioAPI.Handlers.Post.GetAllPost
{
    public class GetAllPostsQueryHandler : IQueryHandler<GetAllPostsQuery, List<PostDto>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetAllPostsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<List<PostDto>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            const string sql = @"
                                SELECT 
                                    p.PostID,
                                    p.Title,
                                    p.Content,
                                    p.VideoURL,
                                    p.AuthorID,
                                    t.TagID AS TagID,  -- Map to a collection using MultiMap
                                    p.Featured,
                                    p.Status,
                                    p.FeaturedImageURL,
                                    p.ViewsCount,
                                    p.AverageRating
                                FROM Posts p
                                INNER JOIN PostTag pt ON pt.PostID = p.PostID
                                INNER JOIN Tags t ON pt.TagID = t.TagID
                                ORDER BY p.PostID;
            ";

            var posts = await connection.QueryAsync<PostDto, Guid, PostDto>(
                sql,  // Use the query from above
                (post, tagId) =>
                {
                    post.TagIds = post.TagIds ?? new List<Guid>();
                    post.TagIds.Add(tagId);
                    return post;
                },
                splitOn: "TagID");

            return posts.ToList();
        }
    }
}
