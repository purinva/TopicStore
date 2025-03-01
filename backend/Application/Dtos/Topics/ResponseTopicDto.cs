namespace Application.Dtos.Topics
{
    public record ResponseTopicDto(
        string Title,
        string Description,
        DateTime EventStart);
}