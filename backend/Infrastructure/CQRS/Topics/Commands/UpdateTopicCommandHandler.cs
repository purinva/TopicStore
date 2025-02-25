using Application.CQRS.Topics.Commands;
using Application.Dtos.Topics;
using AutoMapper;
using Infrastructure.Data.DataDbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Exceptions;

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
                .FirstOrDefaultAsync(t => t.Id == request.updateTopicDto!.Id, 
                cancellationToken);

            if (topic == null)
            {
                throw new NotFoundException($"Topic с id ({request.updateTopicDto!.Id}) не найден");
            }

            mapper.Map(request.updateTopicDto, topic);

            return mapper.Map<ResponseTopicDto>(topic);
        }
    }
}