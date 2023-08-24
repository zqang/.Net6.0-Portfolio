using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.CommandsQueries;
using Portfolio.Data;
using Portfolio.Dtos;
using Portfolio.Models;
using System.Data;

namespace Portfolio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogPostsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public BlogPostsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogPostDto>>> GetBlogPosts()
        {
            var query = new GetBlogPostsQuery();
            var result = await _mediator.Send(query);
            return _mapper.Map<IEnumerable<BlogPostDto>>(result).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BlogPostDto>> Get(int id)
        {
            var query = new GetBlogPostQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }
            return _mapper.Map<BlogPostDto>(result);
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(BlogPostDto), StatusCodes.Status201Created)]
        public async Task<ActionResult<BlogPostDto>> Create(CreateBlogPostCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, _mapper.Map<BlogPostDto>(result));
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<BlogPostDto>> Update(int id, UpdateBlogPostCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);
            return _mapper.Map<BlogPostDto>(result);
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteBlogPostCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
