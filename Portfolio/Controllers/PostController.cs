using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortfolioAPI.CommandsQueries;
using PortfolioAPI.CommandsQueries.Post;
using PortfolioAPI.Handlers.Post.GetAllPost;
using PortfolioAPI.Request.Post;

namespace PortfolioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(List<PostDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _mediator.Send(new GetAllPostsQuery());

            return Ok(posts);
        }


        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateNewPost([FromBody] CreatePostRequest request)
        {
            await _mediator.Send(new CreatePostCommand(
                request.Title,
                request.Content,
                request.AuthorId, 
                request.TagIds, 
                request.Featured, 
                request.Status,
                request.VideoURL,
                request.FeaturedImageURL
                ));

            return Ok();
        }

        [HttpPut("{postId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdatePost([FromRoute] Guid postId, [FromBody] UpdatePostRequest request)
        {
            await _mediator.Send(new UpdatePostCommand(
                postId,
                request.Title,
                request.Content,
                request.VideosURL,
                request.Status,
                request.Featured,
                request.FeaturedImageURL,
                request.TagIds
                ));

            return Ok();
        }

        [HttpDelete("{postId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeletePost(Guid postId)
        {
            await _mediator.Send(new DeletePostCommand(postId));
            return Ok();
        }

    }
}
