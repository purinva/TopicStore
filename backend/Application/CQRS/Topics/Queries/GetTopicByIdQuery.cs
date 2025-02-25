using Application.Dtos.Topics;
using MediatR;

namespace Application.CQRS.Topics.Queries
{
    public class GetTopicByIdQuery 
        : IRequest<ResponseTopicDto>
    {
        public Guid Id { get; set; }
    }
}