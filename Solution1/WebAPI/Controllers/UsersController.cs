using Application.Activities.Commands;
using Application.Users.Commands;
using Application.Users.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        public readonly IMediator _mediator;
        public readonly IMapper _mapper;

        public UsersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUsersById(int id)
        {
            var result = await _mediator.Send(new GetUserByIdQueryCommand() { Id = id });

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<UserGetDto>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("all-users")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllUsers());
            if (result == null)
                return NotFound();
            var mappedResult = _mapper.Map<List<UserGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> GetUserLogin(string userName, string password)
        {
            var result = await _mediator.Send(new GetUserQueryLoginCommand() { UserName = userName, Password = password });
            if (result == null)
                return NotFound();
            var mappedResult = _mapper.Map<UserGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpPost]
        [Route("create-user")]
        public async Task<IActionResult> CreateUser([FromBody] UserPutPostDto user)
        {
            var result = await _mediator.Send(new CreateUserCommand 
            { 
                FirstName = user.FirstName, 
                LastName = user.LastName,
                UserName = user.UserName,
                Password = user.Password,
            });
            var mappedResult = _mapper.Map<UserGetDto>(result);

            return CreatedAtAction(nameof(GetUsersById), new { Id = mappedResult.Id }, mappedResult);
        }

        [HttpPost]
        [Route("{userId}/activities/{activityId}")]
        public async Task<IActionResult> AddActivityToUser(int userId, int activityId)
        {
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
    }
}
