namespace Infrastructure.CQRS.Topics.Commands
{
    public class UpdateTopicCommandHandler(
        ApplicationDbContext dbContext,
        IMapper mapper)
        : IRequestHandler<UpdateTopicCommand, ResponseTopicDto>
    {
        public async Task<ResponseTopicDto> Handle(
            UpdateTopicCommand request, 
            CancellationToken cancellationToken)
        {
            var topic = await dbContext.Topics
                .FirstOrDefaultAsync(t => t.TopicId == request.updateTopicDto!.TopicId, 
                cancellationToken);

            mapper.Map(request.updateTopicDto, topic);
            await dbContext.SaveChangesAsync(cancellationToken);

            return mapper.Map<ResponseTopicDto>(topic);
        }
    }
}