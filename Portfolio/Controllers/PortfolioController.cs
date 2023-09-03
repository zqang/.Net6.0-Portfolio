using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioAPI.Data;
using PortfolioAPI.Models;
using PortfolioAPI.CommandsQueries;
using PortfolioAPI.Dtos;
using System.Data;

namespace PortfolioAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PortfoliosController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PortfoliosController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PortfolioDto>>> GetPortfolios()
        {
            var query = new GetPortfoliosQuery();
            var result = await _mediator.Send(query);
            return _mapper.Map<IEnumerable<PortfolioDto>>(result).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PortfolioDto>> Get(int id)
        {
            var query = new GetPortfolioQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }
            return _mapper.Map<PortfolioDto>(result);
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(PortfolioDto), StatusCodes.Status201Created)]
        public async Task<ActionResult<PortfolioDto>> Create(CreatePortfolioCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, _mapper.Map<PortfolioDto>(result));
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<PortfolioDto>> Update(int id, UpdatePortfolioCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);
            return _mapper.Map<PortfolioDto>(result);
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeletePortfolioCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
