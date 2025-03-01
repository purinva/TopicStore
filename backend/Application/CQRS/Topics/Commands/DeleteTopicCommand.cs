namespace Application.CQRS.Topics.Commands
{
    public class DeleteTopicCommand : IRequest<Unit>
    {
        public Guid topicId { get; set; }
    }
}