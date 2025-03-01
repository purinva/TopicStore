namespace Application.Dtos.Topics
{
    public record CreateTopicDto(
        string Title,
        string Description,
        DateTime EventStart);
}