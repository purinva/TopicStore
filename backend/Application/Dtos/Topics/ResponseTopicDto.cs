namespace Application.Dtos.Topics
{
    public record ResponseTopicDto(
        Guid Id,
        string Title,
        string Description,
        DateTime EventStart,
        Guid UserId);
}