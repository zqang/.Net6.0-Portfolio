using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PortfolioAPI.CommandsQueries;
using PortfolioAPI.Data;
using PortfolioAPI.Dtos;

namespace PortfolioAPI.Handlers
{
    public class GetPortfoliosQueryHandler : IRequestHandler<GetPortfoliosQuery, List<PortfolioDto>>
    {
        private readonly IMapper _mapper;
        private readonly PortfolioDbContext _context;

        public GetPortfoliosQueryHandler(IMapper mapper, PortfolioDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<PortfolioDto>> Handle(GetPortfoliosQuery request, CancellationToken cancellationToken)
        {
            var Portfolio = await _context.Portfolios.ToListAsync(cancellationToken);
            return _mapper.Map<List<PortfolioDto>>(Portfolio);
        }
    }
}
