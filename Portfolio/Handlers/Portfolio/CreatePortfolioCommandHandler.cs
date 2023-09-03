using AutoMapper;
using MediatR;
using PortfolioAPI.CommandsQueries;
using PortfolioAPI.Data;
using PortfolioAPI.Dtos;
using PortfolioAPI.Models;
using Serilog;

namespace PortfolioAPI.Handlers
{
    public class CreatePortfolioCommandHandler : IRequestHandler<CreatePortfolioCommand, PortfolioDto>
    {
        private readonly IMapper _mapper;
        private readonly PortfolioDbContext _context;

        public CreatePortfolioCommandHandler(IMapper mapper, PortfolioDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<PortfolioDto> Handle(CreatePortfolioCommand request, CancellationToken cancellationToken)
        {
            var portfolio = _mapper.Map<Portfolio>(request);

            _context.Portfolios.Add(portfolio);
            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                // Log the inner exception
                Log.Error(ex.InnerException, "An error occurred while saving the blog post.");
            }


            return _mapper.Map<PortfolioDto>(portfolio);
        }
    }
}
