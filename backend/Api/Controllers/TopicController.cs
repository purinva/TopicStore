namespace Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class TopicController(
        IMediator mediator,
        IValidator<CreateTopicDto> createTopicDtoValidator,
        IValidator<UpdateTopicDto> updateTopicDtoValidator)
        : ControllerBase
    {
        [HttpPost]
        public async Task<IResult> Create(
            [FromBody] CreateTopicDto createTopicDto)
        {
            var validationResult = await createTopicDtoValidator
                .ValidateAsync(createTopicDto);

            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.Errors);
            }

            var userIdClaim = User.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            var userId = Guid.Parse(userIdClaim!.Value);

            var command = new CreateTopicCommand
            {
                createTopicDto = createTopicDto,
                userId = userId
            };
            var result = await mediator.Send(command);

            return Results.Ok(result);
        }

        [HttpGet]
        public async Task<IResult> GetAll(
            [FromQuery] int page = 1)
        {
            var userIdClaim = User.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            var userId = Guid.Parse(userIdClaim!.Value);

            var query = new GetAllTopicsQuery
            {
                userId = userId,
                page = page,
                size = 5
            };
            var result = await mediator.Send(query);

            return Results.Ok(result);
        }

        [HttpGet("total")]
        public async Task<IResult> GetTotalTopics()
        {
            var userIdClaim = User.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            var userId = Guid.Parse(userIdClaim!.Value);

            var query = new GetPagesQuery
            {
                userId = userId
            };
            var result = await mediator.Send(query);

            return Results.Ok(result);
        }

        [HttpGet("{topicId}")]
        public async Task<IResult> GetById(Guid topicId)
        {
            var query = new GetTopicByIdQuery { topicId = topicId };
            var result = await mediator.Send(query);

            return Results.Ok(result);
        }

        [HttpPatch]
        public async Task<IResult> Update(
            [FromBody] UpdateTopicDto updateTopicDto)
        {
            var validationResult = await updateTopicDtoValidator
                .ValidateAsync(updateTopicDto);

            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.Errors);
            }

            var command = new UpdateTopicCommand 
            {
                updateTopicDto = updateTopicDto
            };
            var result = await mediator.Send(command);

            return Results.Ok(result);
        }

        [HttpDelete("{topicId}")]
        public async Task<IResult> Delete(Guid topicId)
        {
            var command = new DeleteTopicCommand { topicId = topicId };
            var result = await mediator.Send(command);

            return Results.NoContent();
        }
    }
}