using Application.Users.Queries.GetUser;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public readonly IMediator _mediator;
        public readonly IMapper _mapper;

        public UserController(IMediator mediator, IMapper mapper)
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
    }
}
