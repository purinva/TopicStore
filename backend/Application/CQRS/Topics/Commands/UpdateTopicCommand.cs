using Application.Dtos.Topics;
using MediatR;

namespace Application.CQRS.Topics.Commands
{
    public class UpdateTopicCommand 
        : IRequest<ResponseTopicDto>
    {
        public UpdateTopicDto? updateTopicDto { get; set; }
    }
}