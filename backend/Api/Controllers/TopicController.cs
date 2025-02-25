using Application.CQRS.Topics.Commands;
using Application.CQRS.Topics.Queries;
using Application.Dtos.Topics;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TopicController(IMediator mediator)
        : ControllerBase
    {

        [HttpPost]
        public async Task<IResult> Create(
            [FromBody] CreateTopicDto createTopicDto)
        {
            var command = new CreateTopicCommand 
            {
                createTopicDto = createTopicDto 
            };
            var result = await mediator.Send(command);

            return Results.Ok(result);
        }

        [HttpGet]
        public async Task<IResult> GetAll()
        {
            var query = new GetAllTopicsQuery();
            var result = await mediator.Send(query);

            return Results.Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetById(Guid id)
        {
            var query = new GetTopicByIdQuery { Id = id };
            var result = await mediator.Send(query);

            return Results.Ok(result);
        }

        [HttpPut]
        public async Task<IResult> Update(
            [FromBody] UpdateTopicDto updateTopicDto)
        {
            var command = new UpdateTopicCommand 
            {
                updateTopicDto = updateTopicDto 
            };
            var result = await mediator.Send(command);

            return Results.Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(Guid id)
        {
            var command = new DeleteTopicCommand { Id = id };
            var result = await mediator.Send(command);

            return Results.NoContent();
        }
    }

}
