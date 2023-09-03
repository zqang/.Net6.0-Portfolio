using MediatR;
using PortfolioAPI.Dtos;

namespace PortfolioAPI.CommandsQueries
{

    public class GetPortfoliosQuery : IRequest<List<PortfolioDto>> { }

    public class GetPortfolioQuery : IRequest<PortfolioDto>
    {
        public int Id { get; set; }
    }

    public class CreatePortfolioCommand : IRequest<PortfolioDto>
    {
        public string Title { get; set; }
        public string GithubUrl { get; set; }
        public string? Description { get; set; }
    }

    public class DeletePortfolioCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }

    public class UpdatePortfolioCommand : IRequest<PortfolioDto>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string GithubUrl { get; set; }
        public string? Description { get; set; }
    }

}
