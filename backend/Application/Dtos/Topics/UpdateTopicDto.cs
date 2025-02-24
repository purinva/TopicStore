namespace Application.Dtos.Topics
{
    public record UpdateTopicDto(
        Guid Id,
        string Title,
        string Description,
        DateTime EventStart,
        Guid UserId);
}