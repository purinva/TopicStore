namespace Application.Dtos.Topics
{
    public record ResponseTopicDto(
        Guid TopicId,
        string Title,
        string Description,
        DateTime EventStart);
}