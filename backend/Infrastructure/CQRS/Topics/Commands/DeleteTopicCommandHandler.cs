using Application.CQRS.Topics.Commands;
using AutoMapper;
using Infrastructure.Data.DataDbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Exceptions;

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
                .FirstOrDefaultAsync(t => t.Id == request.Id, 
                cancellationToken);

            if (topic == null)
            {
                throw new NotFoundException($"Topic с id ({request.Id}) не найден");
            }

            topic.IsDeleted = true;
            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}