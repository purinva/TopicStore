using MediatR;

namespace Application.CQRS.Queries
{
    public interface IQuery<out TResponse>
        : IRequest<TResponse>
    {
    }
}
