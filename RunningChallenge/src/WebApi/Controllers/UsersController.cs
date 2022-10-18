using Application.Activities.Commands;
using Application.Marathons.Queries;
using Application.Users.Commands;
using Application.Users.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.ControllersHelpers;
using WebApi.Filter;
using WebApi.Services;
using WebApi.Wrappers;
using WebAPI.ControllersHelpers;
using WebAPI.Dto;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        public readonly IMediator _mediator;
        public readonly IMapper _mapper;
        private readonly ILogger<UsersController> _logger;
        private readonly LoggerHelper _loggerHelper;

        private readonly IUriService _uriService;

        public UsersController(IMediator mediator, 
            IMapper mapper, 
            ILogger<UsersController> logger, 
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
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> GetUsersById(int id)
        {
            _logger.LogInformation(_loggerHelper.LogControllerAndAction(this));

            var result = await _mediator.Send(new GetUserByIdQueryCommand() { Id = id });

            if (result == null)
            {
                _logger.LogWarning($"No user found with Id: {id}.");
                return NotFound();
            }

            var mappedResult = _mapper.Map<UserGetDto>(result);

            foreach(var marathon in mappedResult.Marathons)
            {
                marathon.MemberCount = await _mediator.Send(new CountMembersQuery() { Id = marathon.Id });
                marathon.MemberIdList = await _mediator.Send(new MemberIdListQuery() { Id = marathon.Id });
            }
            mappedResult.TotalTime = await _mediator.Send(new GetTotalTime { Id = id });

            return Ok(new Response<UserGetDto>(mappedResult));
        }

        [HttpGet]
        [Route("all-users")]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            _logger.LogInformation(_loggerHelper.LogControllerAndAction(this));

            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var pagedData = await _mediator.Send(new GetAllUsers() { 
                PageNumber = validFilter.PageNumber,
                PageSize = validFilter.PageSize });
            if (pagedData == null)
            {
                _logger.LogWarning("No users found");
                return NotFound();
            }

            foreach (var user in pagedData)
            {
                user.TotalDistance = user.CalculateTotalDistance();
                user.AveragePace = user.CalculateAveragePace();
            }

            var mappedPagedData = _mapper.Map<List<UserGetDto>>(pagedData);

            foreach (var user in mappedPagedData)
            {
                user.TotalTime = await _mediator.Send(new GetTotalTime { Id = user.Id });
            }

            var totalRecords = await _mediator.Send(new CountAllUsersQuery());
            var pagedResponse = PaginationHelpers.CreatePagedReponse<UserGetDto>(
                mappedPagedData, validFilter, totalRecords, _uriService, route);

            _logger.LogInformation($"Found {mappedPagedData.Count} users");

            return Ok(pagedResponse);
        }

        [HttpGet]
        [Route("login")]
        [Authorize]
        public async Task<IActionResult> GetUserLogin(string userName, string password)
        {
            _logger.LogInformation(_loggerHelper.LogControllerAndAction(this));

            var result = await _mediator.Send(new GetUserQueryLoginCommand() { UserName = userName, Password = password });

            if (result == null)
            {
                _logger.LogWarning($"Login failed, no user found with provided credentials");
                return NotFound();
            }

            var mappedResult = _mapper.Map<UserGetDto>(result);

            return Ok(mappedResult);
        }

        [HttpPost]
        [Route("{userId}/activities/{activityId}")]
        [Authorize]
        public async Task<IActionResult> AddActivityToUser(int userId, int activityId)
        {
            _logger.LogInformation(_loggerHelper.LogControllerAndAction(this));

            var command = new AddActivityToUser
            {
                UserId = userId,
                ActivityId = activityId
            };
            var user = await _mediator.Send(command);

            if (user == null)
                return NotFound();

            return Ok(_mapper.Map<UserGetDto>(user));
        }

        [HttpDelete]
        [Route("deleteUser/{userId}")]
        [Authorize]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            _logger.LogInformation(_loggerHelper.LogControllerAndAction(this));

            var command = new DeleteUser { Id = userId };
            var result = await _mediator.Send(command);

            if (result == null)
            {
                _logger.LogWarning($"Could not delete user. User with id: {userId} was not found.");
                return NotFound();
            }

            return NoContent();
        }
    }
}
