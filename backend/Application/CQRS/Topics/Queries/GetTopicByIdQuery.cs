namespace Application.CQRS.Topics.Queries
{
    public class GetTopicByIdQuery: IRequest<ResponseTopicDto>
    {
        public Guid topicId { get; set; }
    }
}