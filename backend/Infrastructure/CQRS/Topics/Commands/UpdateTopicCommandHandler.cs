using Application.CQRS.Topics.Commands;
using Application.Dtos.Topics;
using AutoMapper;
using Infrastructure.Data.DataDbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
                .Where(t => t.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if (topic == null)
            {
                throw new Exception($"Topic с id ({request.Id}) не найден");
            }

            mapper.Map(request.updateTopicDto, topic);

            return mapper.Map<ResponseTopicDto>(topic);
        }
    }
}