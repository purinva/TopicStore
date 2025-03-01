namespace Infrastructure.CQRS.Topics.Queries
{
    public class GetTopicByIdQueryHandler(
        ApplicationDbContext dbContext,
        IMapper mapper)
        : IRequestHandler<GetTopicByIdQuery, ResponseTopicDto>
    {
        public async Task<ResponseTopicDto> Handle(
            GetTopicByIdQuery request, 
            CancellationToken cancellationToken)
        {
            var topic = await dbContext.Topics
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.TopicId == request.topicId, 
                cancellationToken);

            return mapper.Map<ResponseTopicDto>(topic);
        }
    }
}