using MediatR;
using PortfolioAPI.BuildingBlocks.Queries;
using PortfolioAPI.Handlers.Post.GetAllPost;
using PortfolioAPI.Models;

namespace PortfolioAPI.CommandsQueries.Post
{
    public class GetPostByIdQuery : QueryBase<PostDto>
    {
        
    }
}
