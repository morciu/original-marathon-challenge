﻿using Application.Marathons.Commands;
using Application.Marathons.Queries;
using Application.Users.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApi.ControllersHelpers;
using WebApi.Dto;
using WebApi.Filter;
using WebApi.Services;
using WebApi.Wrappers;
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

        private readonly IUriService _uriService;

        public MarathonController(IMediator mediator, 
            IMapper mapper, 
            ILogger<MarathonController> logger, 
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
        [Authorize]
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
        [Authorize]
        public async Task<IActionResult> DeleteMarathon(int marathonId)
        {
            _logger.LogInformation(_loggerHelper.LogControllerAndAction(this));

            var result = await _mediator.Send(new DeleteMarathonCommand { Id = marathonId });

            if (result == null) return NotFound();

            return NoContent();
        }

        [HttpGet]
        [Route("get-all")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(_loggerHelper.LogControllerAndAction(this));

            var result = await _mediator.Send(new GetAllMarathonsQuery { });
            var mappedResult = _mapper.Map<List<MarathonGetDto>>(result);

            return Ok(mappedResult); 
        }

        [HttpPost]
        [Route("{marathonId}/members/{userId}")]
        [Authorize]
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
        [Authorize]
        public async Task<IActionResult> CountMembers(int marathonId)
        {
            _logger.LogInformation(_loggerHelper.LogControllerAndAction(this));

            var result = await _mediator.Send(new CountMembersQuery { Id = marathonId });

            return Ok(result);
        }

        [HttpGet]
        [Route("average-distance")]
        [Authorize]
        public async Task<IActionResult> AverageDistance(int marathonId)
        {
            _logger.LogInformation(_loggerHelper.LogControllerAndAction(this));

            var result = await _mediator.Send(new AverageDistanceQuery { Id = marathonId });

            return Ok(result);
        }

        [HttpGet]
        [Route("members")]
        [Authorize]
        public async Task<IActionResult> GetMembers([FromQuery] PaginationFilter filter, int marathonId)
        {
            _logger.LogInformation(_loggerHelper.LogControllerAndAction(this));

            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var pagedData = await _mediator.Send(new GetAllMembersQuery { 
                Id = marathonId,
                PageNumber = validFilter.PageNumber,
                PageSize = validFilter.PageSize
            });

            var mappedPagedData = _mapper.Map <List<UserGetDto>>(pagedData);

            var totalRecords = await _mediator.Send(new CountMembersQuery { Id = marathonId });
            var pagedResponse = PaginationHelpers.CreatePagedReponse<UserGetDto>(
                mappedPagedData, validFilter, totalRecords, _uriService, route);

            return Ok(pagedResponse);
        }

        [HttpGet]
        [Route("members-by-distance")]
        [Authorize]
        public async Task<IActionResult> GetUsersByDistance([FromQuery] PaginationFilter filter, int marathonId)
        {
            _logger.LogInformation(_loggerHelper.LogControllerAndAction(this));

            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var pagedData = await _mediator.Send(new UsersByDistanceQuery
            {
                Id = marathonId,
                PageNr = validFilter.PageNumber,
                PageSize = validFilter.PageSize
            });
            
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

            var totalRecords = await _mediator.Send(new CountMembersQuery { Id = marathonId });
            var pagedResponse = PaginationHelpers.CreatePagedReponse<UserGetDto>(
                mappedPagedData, validFilter, totalRecords, _uriService, route);

            return Ok(pagedResponse);
        }

        [HttpGet]
        [Route("{marathonId}/check-progress/{userId}")]
        [Authorize]
        public async Task<IActionResult> CheckProgress(int marathonId, int userId)
        {
            _logger.LogInformation(_loggerHelper.LogControllerAndAction(this));

            var result = await _mediator.Send(new CheckProgressQuery { MarathonId = marathonId, UserId = userId });

            return Ok(result);
        }

        [HttpGet]
        [Route("marathons-with-player/{userId}")]
        [Authorize]
        public async Task<IActionResult> MarathonWithPlayer([FromQuery] PaginationFilter filter, int userId, string filterWord = "all")
        {
            // ensure filterWord is valid
            var validFilterWords = new List<string>() { "all", "active", "finished" };
            if(!validFilterWords.Contains(filterWord)) { filterWord = "all"; }

            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var pagedData = await _mediator.Send(new MarathonsWithUser()
            {
                UserId = userId,
                PageNr = validFilter.PageNumber,
                PageSize = validFilter.PageSize,
                FilterWord = filterWord
            });

            var mappedPagedData = _mapper.Map<List<MarathonListGetDto>>(pagedData);

            foreach (var marathon in mappedPagedData)
            {
                var mar = await _mediator.Send(new GetMarathonByIdCommand { Id = marathon.Id });
                marathon.MemberCount = mar.Members.Count;
            }

            int totalRecords = 0;

            var user = await _mediator.Send(new GetUserByIdQueryCommand { Id = userId });

            switch (filterWord)
            {
                case "all":
                    totalRecords = user.Marathons.Count;
                    break;
                case "active":
                    totalRecords = user.Marathons.Where(m => m.IsDone == false).Count();
                    break;
                case "finished":
                    totalRecords = user.Marathons.Where(m => m.IsDone == true).Count();
                    break;
            }
            var pagedResponse = PaginationHelpers.CreatePagedReponse<MarathonListGetDto>(
                mappedPagedData, validFilter, totalRecords, _uriService, route);

            return Ok(pagedResponse);
        }
    }
}
