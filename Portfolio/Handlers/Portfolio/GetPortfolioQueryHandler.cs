using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PortfolioAPI.Exceptions;
using PortfolioAPI.Data.Repositories;
using PortfolioAPI.CommandsQueries;
using PortfolioAPI.Data;
using PortfolioAPI.Dtos;
using PortfolioAPI.Models;

namespace PortfolioAPI.Handlers
{
    public class GetPortfolioQueryHandler : IRequestHandler<GetPortfolioQuery, PortfolioDto>
    {
        private readonly IMapper _mapper;
        private readonly PortfolioDbContext _context;

        public GetPortfolioQueryHandler(IMapper mapper, PortfolioDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<PortfolioDto> Handle(GetPortfolioQuery request, CancellationToken cancellationToken)
        {
            var Portfolio = await _context.Portfolios.FindAsync(request.Id);

            if (Portfolio == null)
            {
                throw new NotFoundException(nameof(Portfolio), request.Id);
            }

            return _mapper.Map<PortfolioDto>(Portfolio);
        }
    }
}
