namespace Application.CQRS.Topics.Commands
{
    public class CreateTopicCommand : IRequest<ResponseTopicDto>
    {
        public CreateTopicDto? createTopicDto { get; set; }
        public Guid userId { get; set; }
    }
}