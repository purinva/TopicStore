namespace Application.CQRS.Topics.Queries
{
    public class GetAllTopicsQuery : IRequest<List<ResponseTopicDto>>
    {
        public Guid userId { get; set; }
    }
}