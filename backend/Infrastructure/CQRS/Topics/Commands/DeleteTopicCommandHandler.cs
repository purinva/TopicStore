namespace Infrastructure.CQRS.Topics.Commands
{
    public class DeleteTopicCommandHandler(
        ApplicationDbContext dbContext)
        : IRequestHandler<DeleteTopicCommand, Unit>
    {
        public async Task<Unit> Handle(
            DeleteTopicCommand request,
            CancellationToken cancellationToken)
        {
            var topic = await dbContext.Topics
                .FirstOrDefaultAsync(t => t.TopicId == request.topicId,
                cancellationToken);

            topic!.IsDeleted = true;
            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}