namespace Infrastructure.CQRS.Topics.Queries
{
    public class GetAllTopicsQueryHandler(
        ApplicationDbContext dbContext,
        IMapper mapper)
        : IRequestHandler<GetAllTopicsQuery, List<ResponseTopicDto>>
    {
        public async Task<List<ResponseTopicDto>> Handle(
            GetAllTopicsQuery request,
            CancellationToken cancellationToken)
        {
            var userId = request.userId;

            var topics = await dbContext.Topics
                .AsNoTracking()
                .Where(u => u.UserId == userId)
                .Skip((request.page - 1) * request.size)
                .Take(request.size)
                .ToListAsync(cancellationToken);

            return topics
                .Select(t => mapper.Map<ResponseTopicDto>(t))
                .ToList();
        }
    }
}