using MediatR;

namespace Application.CQRS.Topics.Commands
{
    public class DeleteTopicCommand
        : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}