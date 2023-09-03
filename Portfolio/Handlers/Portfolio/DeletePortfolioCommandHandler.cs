using AutoMapper;
using MediatR;
using PortfolioAPI.Dtos;
using PortfolioAPI.Exceptions;
using PortfolioAPI.CommandsQueries;
using PortfolioAPI.Models;
using PortfolioAPI.Repositories;

namespace PortfolioAPI.Handlers
{
    public class DeletePortfolioCommandHandler : IRequestHandler<DeletePortfolioCommand, Unit>
    {
        private readonly IPortfolioRepository _PortfolioRepository;
        private readonly IMapper _mapper;

        public DeletePortfolioCommandHandler(IPortfolioRepository PortfolioRepository, IMapper mapper)
        {
            _PortfolioRepository = PortfolioRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeletePortfolioCommand request, CancellationToken cancellationToken)
        {
            var Portfolio = await _PortfolioRepository.GetByIdAsync(request.Id);

            if (Portfolio == null)
            {
                throw new NotFoundException(nameof(Portfolio), request.Id);
            }

            await _PortfolioRepository.DeleteAsync(request.Id);

            return Unit.Value;
        }
    }

}