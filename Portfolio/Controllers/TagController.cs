using MediatR;
using Microsoft.AspNetCore.Mvc;
using PortfolioAPI.Handlers.Tag.CreateTag;
using PortfolioAPI.Handlers.Tag.DeleteTag;
using PortfolioAPI.Handlers.Tag.GetAllTag;
using PortfolioAPI.Request.Tag;

namespace PortfolioAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TagController : ControllerBase
{
    private readonly IMediator _mediator;

    public TagController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("")]
    [ProducesResponseType(typeof(List<TagDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTags()
    {
        var posts = await _mediator.Send(new GetAllTagsQuery());

        return Ok(posts);
    }


    [HttpPost("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateNewTag([FromBody] CreateTagRequest request)
    {
        var result = await _mediator.Send(new CreateTagCommand(request.Name, request.Description));

        return Ok(result);
    }


    [HttpDelete("{tagId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteTag(Guid tagId)
    {
        await _mediator.Send(new DeleteTagCommand(tagId));
        return Ok();
    }
}