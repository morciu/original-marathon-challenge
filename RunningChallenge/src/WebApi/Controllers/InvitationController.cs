using Application.Invitations.Commands;
using Application.Invitations.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.ControllersHelpers;
using WebApi.Dto;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvitationController : ControllerBase
    {
        public readonly IMediator _mediator;
        public readonly IMapper _mapper;

        public InvitationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("create-invitation")]
        public async Task<IActionResult> CreateInvitation([FromBody] InvitationPutPostDto body)
        {
            var result = await _mediator.Send(new CreateInvitation { SenderId = body.SenderId, ReceiverId = body.ReceiverId, MarathonId = body.MarathonId });
            var mappedResult = _mapper.Map<InvitationGetDto>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("unanswered/{receiverId}")]
        [Authorize]
        public async Task<IActionResult> CheckUnansweredInvitations(int receiverId)
        {
            var result = await _mediator.Send(new CheckUnansweredInvitations { ReceiverId = receiverId });
            var mappedResult = _mapper.Map<List<InvitationGetDto>>(result);

            return Ok(mappedResult);
        }

        [HttpPut]
        [Route("answer/{invitationId}")]
        [Authorize]
        public async Task<IActionResult> AnswerInvitation(int invitationId, bool answer)
        {
            await _mediator.Send(new AnswerInvitation { InvitationId = invitationId, Answer = answer });

            return Ok();
        }
    }
}
