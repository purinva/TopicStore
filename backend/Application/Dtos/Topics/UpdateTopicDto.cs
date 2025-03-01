namespace Application.Dtos.Topics
{
    public record UpdateTopicDto(
        Guid TopicId,
        string Title,
        string Description,
        DateTime EventStart);
}