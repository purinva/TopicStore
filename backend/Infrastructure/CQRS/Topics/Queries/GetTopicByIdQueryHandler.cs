using Application.CQRS.Topics.Queries;
using Application.Dtos.Topics;
using AutoMapper;
using Infrastructure.Data.DataDbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Exceptions;

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
                .FirstOrDefaultAsync(t => t.Id == request.Id, 
                cancellationToken);

            if (topic == null)
            {
                throw new NotFoundException($"Topic с id ({request.Id}) не найден");
            }

            return mapper.Map<ResponseTopicDto>(topic);
        }
    }
}
