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
                                SELECT p.*, t.TagName AS TagName
                                FROM Posts p
                                LEFT JOIN PostTag pt ON pt.PostID = p.PostID
                                LEFT JOIN Tags t ON pt.TagID = t.TagID
                                ORDER BY p.PostID;
                            ";

            var posts = await connection.QueryAsync<PostDto>(sql, cancellationToken);

            return posts.DistinctBy(p => p.Id).ToList();

        }
    }
}
