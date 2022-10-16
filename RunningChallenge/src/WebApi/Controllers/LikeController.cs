using Application.Likes.Commands;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        public readonly IMediator _mediator;
        public readonly IMapper _mapper;

        public LikeController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("create-like")]
        public async Task<IActionResult> CreateLike([FromBody] LikePutPostDto body)
        {
            var result = await _mediator.Send(new CreateLikeCommand { SenderId = body.SenderId, ActivityId = body.ActivityId });
            var mappedResult = _mapper.Map<LikeGetDto>(result);

            return Ok(mappedResult);
        }
    }
}
