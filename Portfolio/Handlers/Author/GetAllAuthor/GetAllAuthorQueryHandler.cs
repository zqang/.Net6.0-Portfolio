using Dapper;
using PortfolioAPI.BuildingBlocks;
using PortfolioAPI.BuildingBlocks.Queries;

namespace PortfolioAPI.Handlers.Author.GetAllAuthor
{
    public class GetAllAuthorQueryHandler : IQueryHandler<GetAllAuthorQuery, List<AuthorDto>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetAllAuthorQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<List<AuthorDto>> Handle(GetAllAuthorQuery request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            const string sql = @"
                                SELECT [AuthorID],[Name],[Email],[Bio],[RegistrationDate],[Status],[UserID] 
                                FROM [Blog].[dbo].[Authors]
                            ";

            var authors = await connection.QueryAsync<AuthorDto>(sql, cancellationToken).ConfigureAwait(false);

            return authors.ToList();
        }
    }
}
