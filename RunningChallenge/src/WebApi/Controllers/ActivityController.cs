using Application.Activities.Commands;
using Application.Activities.Queries;
using Application.Marathons.Commands;
using Application.Users.Commands.UpdateUser;
using AutoMapper;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.ControllersHelpers;
using WebApi.Filter;
using WebApi.Services;
using WebAPI.ControllersHelpers;
using WebAPI.Dto;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        public readonly IMediator _mediator;
        public readonly IMapper _mapper;
        private readonly ILogger<ActivityController> _logger;
        private readonly LoggerHelper _loggerHelper;

        private readonly IUriService _uriService;

        public ActivityController(IMediator mediator, 
            IMapper mapper, 
            ILogger<ActivityController> logger, 
            LoggerHelper loggerHelper,
            IUriService uriService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
            _loggerHelper = loggerHelper;
            _uriService = uriService;
        }

        [HttpGet]
        [Route("all-activities")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(_loggerHelper.LogControllerAndAction(this));

            var result = await _mediator.Send(new GetAllActivitiesQuery());
            if(result == null)
            {
                _logger.LogWarning("No activities found.");
                return NotFound();
            }

            _logger.LogInformation($"Found {result.Count} activities.");
            var mappedResult = _mapper.Map<List<ActivityGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetActivityById(int id)
        {
            _logger.LogInformation(_loggerHelper.LogControllerAndAction(this));

            var result = await _mediator.Send(new GetActivityByIdQuery(){ Id = id });

            if (result == null)
            {
                _logger.LogWarning($"No activity found with id: {id}.");
                return NotFound();
            }

            var mappedResult = _mapper.Map<ActivityGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("user-activities/{id}")]
        public async Task<IActionResult> GetAllUserActivities([FromQuery] PaginationFilter filter, int id)
        {
            _logger.LogInformation(_loggerHelper.LogControllerAndAction(this));

            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var pagedData = await _mediator.Send(new GetAllUserActivitiesQuery() 
            { 
                UserId = id,
                PageNr = validFilter.PageNumber,
                PageSize = validFilter.PageSize
            });

            if (pagedData == null)
            {
                _logger.LogWarning($"No activity found for user with id: {id}");
                return NotFound();
            }

            var mappedPagedData = _mapper.Map<List<ActivityGetDto>>(pagedData);

            var totalRecords = await _mediator.Send(new CountUserActivitiesQuery { Id = id });
            var pagedResponse = PaginationHelpers.CreatePagedReponse<ActivityGetDto>(
                mappedPagedData, validFilter, totalRecords, _uriService, route);

            // Check if the marathon events have ended (iff all users have finished / earned a medal)
            await _mediator.Send(new CloseCompletedMarahons { UserId = id });

            _logger.LogInformation($"Found {pagedData.Count} activities for user with id: {id}");
            return Ok(pagedResponse);
        }

        [HttpPost]
        [Route("create-activity")]
        public async Task<IActionResult> CreateActivity([FromBody] ActivityPutPostDto activity)
        {
            _logger.LogInformation(_loggerHelper.LogControllerAndAction(this));

            var result = await _mediator.Send(new CreateActivityCommand
            {
                RunnerId = activity.UserId,
                Distance = activity.Distance,
                Date = activity.Date,
                Duration = activity.Duration,
            });

            if(result == null)
            {
                _logger.LogWarning("Failed to create activity");
                _logger.LogDebug("Tried to create activity with the following values\n" +
                    $"RunnerId: {activity.UserId}\n" +
                    $"Distance: {activity.Distance}\n" +
                    $"Date: {activity.Date}\n" +
                    $"Duration: {activity.Duration}");
                return NotFound();
            }

            var mappedResult = _mapper.Map<ActivityGetDto>(result);
            _logger.LogInformation($"Succesfully created activity with id: {mappedResult.Id}.");

            // Update user Marathons and award medals
            await _mediator.Send(new UpdateUserMarathonStatusCommand { Id = activity.UserId });

            // Check if the marathon events the activity is registered in have ended (iff all users have finished / earned a medal)
            await _mediator.Send(new CloseCompletedMarahons { UserId = activity.UserId });


            return CreatedAtAction(nameof(GetActivityById), new { id = mappedResult.Id }, mappedResult);
        }

        [HttpDelete]
        [Route("deleteActivity/{activityId}")]
        public async Task<IActionResult> DeleteActivity(int activityId)
        {
            _logger.LogInformation(_loggerHelper.LogControllerAndAction(this));

            var command = new DeleteActivity { Id = activityId };
            var result = await _mediator.Send(command);

            if (result == null) {
                _logger.LogWarning($"Failed to delete activity. No activity found with id: {activityId}.");
                return NotFound(); }

            _logger.LogInformation($"Successfully deleted activity with id: {activityId}.");
            return NoContent();
        }
    }
}
