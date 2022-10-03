using Application.Abstract;
using Application.Invitations.Queries;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Invitations.QueryHandlers
{
    public class CheckUnansweredInvitationsHandler : IRequestHandler<CheckUnansweredInvitations, List<Invitation>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CheckUnansweredInvitationsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Invitation>> Handle(CheckUnansweredInvitations request, CancellationToken cancellationToken)
        {
            var receiver = await _unitOfWork.UserRepository.GetUser(request.ReceiverId);
            if (receiver == null) return null;

            var invitations = await _unitOfWork.InvitationRepository.CheckUnansweredInvitations(receiver);

            return invitations;
        }
    }
}
