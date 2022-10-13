using Application.Activities.Commands;
using Application.Activities.Queries;
using Application.Medals.Commands;
using Application.Medals.Queries;
using AutoMapper;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.ControllersHelpers;
using WebApi.Dto;
using WebApi.Filter;
using WebApi.Services;
using WebAPI.ControllersHelpers;
using WebAPI.Dto;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedalController : ControllerBase
    {
        public readonly IMediator _mediator;
        public readonly IMapper _mapper;
        private readonly ILogger<MedalController> _logger;
        private readonly LoggerHelper _loggerHelper;

        private readonly IUriService _uriService;

        public MedalController(IMediator mediator, IMapper mapper, ILogger<MedalController> logger, LoggerHelper loggerHelper, IUriService uriService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
            _loggerHelper = loggerHelper;
            _uriService = uriService;
        }

        [HttpPost]
        [Route("create-medal")]
        public async Task<IActionResult> CreateMedal(int userId, int marathonId)
        {
            var result = await _mediator.Send(new CreateMedalCommand { UserId = userId, MarathonId = marathonId });
            var mappedResult = _mapper.Map<MedalGetDto>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("{userId}/medals")]
        public async Task<IActionResult> GetUserMedals(int userId)
        {
            var result = await _mediator.Send(new GetUserMedalsQuery { UserId = userId });
            var mappedResult = _mapper.Map<List<MedalGetDto>>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("{userId}/marathons/{marathonId}/medals/")]
        public async Task<IActionResult> GetUserMedalsInMarathon(int userId, int marathonId)
        {
            var result = await _mediator.Send(new GetUserMedalsInMarathonQuery { UserId = userId, MarathonId = marathonId });
            var mappedResult = _mapper.Map<List<MedalGetDto>>(result);

            return Ok(mappedResult);
        }
    }
}
