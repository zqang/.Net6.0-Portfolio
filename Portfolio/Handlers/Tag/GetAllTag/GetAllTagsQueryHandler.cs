using Dapper;
using PortfolioAPI.BuildingBlocks;
using PortfolioAPI.BuildingBlocks.Queries;
using PortfolioAPI.Data.Repositories.Tag;

namespace PortfolioAPI.Handlers.Tag.GetAllTag
{
    public class GetAllTagsQueryHandler : IQueryHandler<GetAllTagsQuery, List<TagDto>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory; 
        public GetAllTagsQueryHandler(ISqlConnectionFactory sqlConnectionFactory) 
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<List<TagDto>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            const string sql = @"
                                SELECT [TagID]
                                      ,[Name]
                                      ,[Description]
                                  FROM [Blog].[dbo].[Tags]
                            ";

            var tags = await connection.QueryAsync<TagDto>(sql, cancellationToken).ConfigureAwait(false);

            return tags.ToList();
        }
    }
}
