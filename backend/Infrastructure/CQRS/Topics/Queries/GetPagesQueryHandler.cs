namespace Infrastructure.CQRS.Topics.Queries
{
    class GetPagesQueryHandler(
        ApplicationDbContext dbContext)
        : IRequestHandler<GetPagesQuery, int>
    {
        public async Task<int> Handle(
            GetPagesQuery request, 
            CancellationToken cancellationToken)
        {
            var userId = request.userId;
            var topicsPerPage = 5;

            var totalTopics = await dbContext.Topics
                .AsNoTracking()
                .Where(u => u.UserId == userId)
                .CountAsync(cancellationToken);

            return (int)Math.Ceiling((double)totalTopics / topicsPerPage);
        }
    }
}