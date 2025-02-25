using Application.CQRS.Topics.Queries;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Data.DataDbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.CQRS.Topics.Queries
{
    public class GetAllTopicsQueryHandler(
        ApplicationDbContext dbContext)
        : IRequestHandler<GetAllTopicsQuery, List<Topic>>
    {

        public async Task<List<Topic>> Handle(
            GetAllTopicsQuery request,
            CancellationToken cancellationToken)
        {
            var topics = await dbContext.Topics
                .ToListAsync(cancellationToken);

            return topics;
        }
    }
}