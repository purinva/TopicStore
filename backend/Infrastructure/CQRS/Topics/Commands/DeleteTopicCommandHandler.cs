using Application.CQRS.Topics.Commands;
using AutoMapper;
using Infrastructure.Data.DataDbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.CQRS.Topics.Commands
{
    public class DeleteTopicCommandHandler(
        ApplicationDbContext dbContext,
        IMapper mapper)
        : IRequestHandler<DeleteTopicCommand, Unit>
    {
        public async Task<Unit> Handle(
            DeleteTopicCommand request, 
            CancellationToken cancellationToken)
        {
            var topic = await dbContext.Topics
                .Where(t => t.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if (topic == null)
            {
                throw new Exception($"Topic с id ({request.Id}) не найден");
            }

            topic.IsDeleted = true;
            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}