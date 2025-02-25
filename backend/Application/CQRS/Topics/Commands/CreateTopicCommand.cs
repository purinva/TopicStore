using Application.Dtos.Topics;
using MediatR;

namespace Application.CQRS.Topics.Commands
{
    public class CreateTopicCommand
        : IRequest<ResponseTopicDto>
    {
        public CreateTopicDto? createTopicDto { get; set; }
    }
}