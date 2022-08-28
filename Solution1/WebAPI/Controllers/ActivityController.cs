using Application.Activities.Queries;
using AutoMapper;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        public readonly IMediator _mediator;
        public readonly IMapper _mapper;

        public ActivityController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("all-activities")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllActivitiesQuery());
            if(result == null)
            {
                return NotFound();
            }
            var mappedResult = _mapper.Map<List<ActivityGetDto>>(result);
            return Ok(mappedResult);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetActivityById(int id)
        {
            var result = await _mediator.Send(new GetActivityByIdQuery(){ Id = id });
            if (result == null)
                return NotFound();
            var mappedResult = _mapper.Map<ActivityGetDto>(result);
            return Ok(mappedResult);
        }
        [HttpGet]
        [Route("user-activities/{id}")]
        public async Task<IActionResult> GetAllUserActivities(int id)
        {
            var result = await _mediator.Send(new GetAllUserActivitiesQuery() { UserId = id });
            if (result == null)
                return NotFound();
            var mappedResult = _mapper.Map<List<ActivityGetDto>>(result);
            return Ok(mappedResult);
        }
    }
}
