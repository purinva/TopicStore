namespace Application.CQRS.Topics.Queries
{
    public class GetAllTopicsQuery : IRequest<List<ResponseTopicDto>>
    {
        public Guid userId { get; set; }
        public int page { get; set; }
        public int size { get; set; }
    }
}