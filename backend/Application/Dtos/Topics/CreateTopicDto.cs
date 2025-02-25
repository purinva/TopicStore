namespace Application.Dtos.Topics
{
    public record CreateTopicDto(
        Guid Id,
        string Title,
        string Description,
        DateTime EventStart,
        Guid UserId);
}