using Application.Marathons.Commands;
using Application.Marathons.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.ControllersHelpers;
using WebAPI.Dto;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarathonController : ControllerBase
    {
        public readonly IMediator _mediator;
        public readonly IMapper _mapper;
        private readonly ILogger<ActivityController> _logger;
        private readonly ControllerHelper _controllerHelper;

        public MarathonController(IMediator mediator, IMapper mapper, ILogger<ActivityController> logger, ControllerHelper controllerHelper)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
            _controllerHelper = controllerHelper;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetMarathonById(int id)
        {
            var actionName = _controllerHelper.GetActionName(this);
            var controllerName = _controllerHelper.GetControllerName(this);

            _logger.LogInformation($"Controller: {controllerName}\n" +
                $"Action: {actionName}\n" +
                $"Called at: {DateTime.Now.TimeOfDay}");

            var result = await _mediator.Send(new GetMarathonByIdCommand { Id = id });

            if (result == null)
            {
                _logger.LogWarning($"No marathon found with Id: {id}.");
                return NotFound();
            }

            var mappedResult = _mapper.Map<MarathonGetDto>(result);

            return Ok(mappedResult);
        }

        [HttpPost]
        [Route("create-marathon")]
        public async Task<IActionResult> CreateMarathon([FromBody] MarathonPutPostDto body)
        {
            var actionName = _controllerHelper.GetActionName(this);
            var controllerName = _controllerHelper.GetControllerName(this);

            _logger.LogInformation($"Controller: {controllerName}\n" +
                $"Action: {actionName}\n" +
                $"Called at: {DateTime.Now.TimeOfDay}");

            var result = await _mediator.Send(new CreateMarathonCommand { FirstMemberId = body.FirstUserId });

            var mappedResult = _mapper.Map<MarathonGetDto>(result);

            return CreatedAtAction(nameof(GetMarathonById), new { Id = mappedResult.Id }, mappedResult);
        }

        [HttpDelete]
        [Route("delete/{marathonId}")]
        public async Task<IActionResult> DeleteMarathon(int marathonId)
        {
            var actionName = _controllerHelper.GetActionName(this);
            var controllerName = _controllerHelper.GetControllerName(this);

            _logger.LogInformation($"Controller: {controllerName}\n" +
                $"Action: {actionName}\n" +
                $"Called at: {DateTime.Now.TimeOfDay}");

            var result = await _mediator.Send(new DeleteMarathonCommand { Id = marathonId });

            if (result == null) return NotFound();

            return NoContent();
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var actionName = _controllerHelper.GetActionName(this);
            var controllerName = _controllerHelper.GetControllerName(this);

            _logger.LogInformation($"Controller: {controllerName}\n" +
                $"Action: {actionName}\n" +
                $"Called at: {DateTime.Now.TimeOfDay}");

            var result = await _mediator.Send(new GetAllMarathonsQuery { });
            var mappedResult = _mapper.Map<List<MarathonGetDto>>(result);

            return Ok(mappedResult); 
        }

        [HttpPost]
        [Route("{marathonId}/members/{userId}")]
        public async Task<IActionResult> AddUserToMarathon(int marathonId, int userId)
        {
            var command = new AddUserToMaratonCommand { MarathonId = marathonId, UserId = userId };
            var marathon = await _mediator.Send(command);
            if (marathon == null) return NotFound();

            var mappedResult = _mapper.Map<MarathonGetDto>(marathon);

            return Ok(mappedResult);
        }
    }
}
