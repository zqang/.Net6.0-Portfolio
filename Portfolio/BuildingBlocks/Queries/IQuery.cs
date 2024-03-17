using MediatR;

namespace PortfolioAPI.BuildingBlocks.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}