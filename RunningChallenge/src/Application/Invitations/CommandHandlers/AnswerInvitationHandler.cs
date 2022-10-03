using Application.Abstract;
using Application.Invitations.Commands;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Invitations.CommandHandlers
{
    public class AnswerInvitationHandler : IRequestHandler<AnswerInvitation, Invitation>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AnswerInvitationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Invitation> Handle(AnswerInvitation request, CancellationToken cancellationToken)
        {
            var invitation = await _unitOfWork.InvitationRepository.GetInvtiation(request.InvitationId);
            var marathon = await _unitOfWork.MarathonRepository.GetMarathon(invitation.Marathon.Id);
            var user = await _unitOfWork.UserRepository.GetUser(invitation.Receiver.Id);

            if (invitation == null || marathon == null || user == null) return null;

            if(request.Answer == true)
            {
                marathon.Members = await _unitOfWork.MarathonRepository.GetAllUsers(marathon.Id);
                marathon.Members.Add(user);
            }
            invitation.IsActive = false;
            await _unitOfWork.Save();

            return invitation;
        }
    }
}
