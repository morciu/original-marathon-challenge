using Application.Invitations.Commands;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;

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
        [Route("/create-invitation")]
        public async Task<IActionResult> CreateInvitation(int senderId, int receiverId, int marathonId)
        {
            var result = await _mediator.Send(new CreateInvitation { SenderId = senderId, ReceiverId = receiverId, MarathonId = marathonId });
            var mappedResult = _mapper.Map<InvitationGetDto>(result);

            return Ok(mappedResult);
        }
    }
}
