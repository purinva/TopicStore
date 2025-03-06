namespace Application.CQRS.Topics.Queries
{
    public class GetPagesQuery : IRequest<int>
    {
        public Guid userId { get; set; }
    }
}