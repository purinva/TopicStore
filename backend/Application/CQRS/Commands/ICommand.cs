using MediatR;

namespace Application.CQRS.Commands
{
    public interface ICommand<out TResponse>
        : IRequest<TResponse>
    {
    }

    public interface ICommand : IRequest<Unit>
    {
    }
}