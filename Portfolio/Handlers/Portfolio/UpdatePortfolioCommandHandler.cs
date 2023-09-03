using AutoMapper;
using MediatR;
using PortfolioAPI.Exceptions;
using PortfolioAPI.CommandsQueries;
using PortfolioAPI.Dtos;
using PortfolioAPI.Models;
using PortfolioAPI.Repositories;

namespace PortfolioAPI.Handlers
{
    public class UpdatePortfolioCommandHandler : IRequestHandler<UpdatePortfolioCommand, PortfolioDto>
    {
        private readonly IMapper _mapper;
        private readonly IPortfolioRepository _PortfolioRepository;

        public UpdatePortfolioCommandHandler(IMapper mapper, IPortfolioRepository PortfolioRepository)
        {
            _mapper = mapper;
            _PortfolioRepository = PortfolioRepository;
        }

        public async Task<PortfolioDto> Handle(UpdatePortfolioCommand request, CancellationToken cancellationToken)
        {
            var Portfolio = await _PortfolioRepository.GetByIdAsync(request.Id);

            if (Portfolio == null)
            {
                throw new NotFoundException(nameof(Portfolio), request.Id);
            }

            _mapper.Map(request, Portfolio);

            await _PortfolioRepository.UpdateAsync(Portfolio);

            return _mapper.Map<PortfolioDto>(Portfolio);
        }
    }
}
