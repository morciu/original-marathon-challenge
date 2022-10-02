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
        private readonly ILogger<MarathonController> _logger;
        private readonly LoggerHelper _loggerHelper;

        public MarathonController(IMediator mediator, IMapper mapper, ILogger<MarathonController> logger, LoggerHelper loggerHelper)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
            _loggerHelper = loggerHelper;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetMarathonById(int id)
        {
            _logger.LogInformation(_loggerHelper.LogControllerAndAction(this));

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
            _logger.LogInformation(_loggerHelper.LogControllerAndAction(this));

            var result = await _mediator.Send(new CreateMarathonCommand { FirstMemberId = body.FirstUserId });

            if (result == null)
            {
                _logger.LogWarning($"Could not create Marathon having first user with Id: {body.FirstUserId}.");
                return NotFound();
            }

            var mappedResult = _mapper.Map<MarathonGetDto>(result);

            return CreatedAtAction(nameof(GetMarathonById), new { Id = mappedResult.Id }, mappedResult);
        }

        [HttpDelete]
        [Route("delete/{marathonId}")]
        public async Task<IActionResult> DeleteMarathon(int marathonId)
        {
            _logger.LogInformation(_loggerHelper.LogControllerAndAction(this));

            var result = await _mediator.Send(new DeleteMarathonCommand { Id = marathonId });

            if (result == null) return NotFound();

            return NoContent();
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(_loggerHelper.LogControllerAndAction(this));

            var result = await _mediator.Send(new GetAllMarathonsQuery { });
            var mappedResult = _mapper.Map<List<MarathonGetDto>>(result);

            return Ok(mappedResult); 
        }

        [HttpPost]
        [Route("{marathonId}/members/{userId}")]
        public async Task<IActionResult> AddUserToMarathon(int marathonId, int userId)
        {
            _logger.LogInformation(_loggerHelper.LogControllerAndAction(this));

            var command = new AddUserToMaratonCommand { MarathonId = marathonId, UserId = userId };
            var marathon = await _mediator.Send(command);
            if (marathon == null) return NotFound();

            var mappedResult = _mapper.Map<MarathonGetDto>(marathon);

            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("member-count")]
        public async Task<IActionResult> CountMembers(int marathonId)
        {
            _logger.LogInformation(_loggerHelper.LogControllerAndAction(this));

            var result = await _mediator.Send(new CountMembersQuery { Id = marathonId });

            return Ok(result);
        }

        [HttpGet]
        [Route("average-distance")]
        public async Task<IActionResult> AverageDistance(int marathonId)
        {
            _logger.LogInformation(_loggerHelper.LogControllerAndAction(this));

            var result = await _mediator.Send(new AverageDistanceQuery { Id = marathonId });

            return Ok(result);
        }

        [HttpGet]
        [Route("members")]
        public async Task<IActionResult> GetMembers(int marathonId)
        {
            _logger.LogInformation(_loggerHelper.LogControllerAndAction(this));

            var result = await _mediator.Send(new GetAllMembersQuery { Id = marathonId });
            return Ok(result);
        }

        [HttpGet]
        [Route("members-by-distance")]
        public async Task<IActionResult> GetUsersByDistance(int marathonId)
        {
            _logger.LogInformation(_loggerHelper.LogControllerAndAction(this));

            var result = await _mediator.Send(new UsersByDistanceQuery { Id = marathonId });
            var mappedResult = new List<UserGetDto>();
            foreach (var user in result)
            {
                user.TotalDistance = user.CalculateTotalDistance();
                user.TotalTime = user.CalculateTotalTime();
                user.AveragePace = user.CalculateAveragePace();
                mappedResult.Add(_mapper.Map<UserGetDto>(user));
            }

            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("{marathonId}/check-progress/{userId}")]
        public async Task<IActionResult> CheckProgress(int marathonId, int userId)
        {
            _logger.LogInformation(_loggerHelper.LogControllerAndAction(this));

            var result = await _mediator.Send(new CheckProgressQuery { MarathonId = marathonId, UserId = userId });

            return Ok(result);
        }
    }
}
