using Application.CQRS.Topics.Queries;
using Application.Dtos.Topics;
using AutoMapper;
using Infrastructure.Data.DataDbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
                .Where(t => t.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if (topic == null)
            {
                throw new Exception($"Topic с id ({request.Id}) не найден");
            }

            return mapper.Map<ResponseTopicDto>(topic);
        }
    }
}
