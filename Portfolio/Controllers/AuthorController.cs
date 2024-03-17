using MediatR;
using Microsoft.AspNetCore.Mvc;
using PortfolioAPI.Handlers.Author.CreateAuthor;
using PortfolioAPI.Handlers.Author.DeleteAuthor;
using PortfolioAPI.Handlers.Post.GetAllPost;
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
    [ProducesResponseType(typeof(List<PostDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAuthors()
    {
        var posts = await _mediator.Send(new GetAllPostsQuery());

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


    [HttpDelete("{postId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteAuthor(Guid postId)
    {
        await _mediator.Send(new DeleteAuthorCommand(postId));
        return Ok();
    }
}