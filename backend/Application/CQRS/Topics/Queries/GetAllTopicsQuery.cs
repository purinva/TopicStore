using Domain.Entities;
using MediatR;

namespace Application.CQRS.Topics.Queries
{
    public class GetAllTopicsQuery 
        : IRequest<List<Topic>>
    {
    }
}