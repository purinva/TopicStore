using Application.CQRS.Topics.Commands;
using Application.Dtos.Topics;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Data.DataDbContext;
using MediatR;

namespace Infrastructure.CQRS.Topics.Commands
{
    public class CreateTopicCommandHandler(
        ApplicationDbContext dbContext,
        IMapper mapper)
        : IRequestHandler<CreateTopicCommand, ResponseTopicDto>
    {
        public async Task<ResponseTopicDto> Handle(
            CreateTopicCommand request,
            CancellationToken cancellationToken)
        {
            var topic = mapper.Map<Topic>(request.createTopicDto);

            await dbContext.Topics.AddAsync(topic, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return mapper.Map<ResponseTopicDto>(topic);
        }
    }
}