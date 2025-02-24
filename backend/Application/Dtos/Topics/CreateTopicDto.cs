namespace Application.Dtos.Topics
{
    record CreateTopicDto(
        Guid Id,
        string Title,
        string Description,
        DateTime EventStart,
        Guid UserId);
}