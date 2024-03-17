using MediatR;
using Microsoft.AspNetCore.Mvc;
using PortfolioAPI.Handlers.Author.CreateAuthor;
using PortfolioAPI.Handlers.Author.DeleteAuthor;
using PortfolioAPI.Handlers.Author.GetAllAuthor;
using PortfolioAPI.Request.Author;

namespace PortfolioAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthorController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("")]
    [ProducesResponseType(typeof(List<AuthorDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAuthors()
    {
        var posts = await _mediator.Send(new GetAllAuthorQuery());

        return Ok(posts);
    }


    [HttpPost("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateNewAuthor([FromBody] CreateAuthorRequest request)
    {
        var result = await _mediator.Send(new CreateAuthorCommand(
            request.UserID,
            request.Name,
            request.Bio
            ));

        return Ok(result);
    }


    [HttpDelete("{authorId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteAuthor(Guid authorId)
    {
        await _mediator.Send(new DeleteAuthorCommand(authorId));
        return Ok();
    }
}