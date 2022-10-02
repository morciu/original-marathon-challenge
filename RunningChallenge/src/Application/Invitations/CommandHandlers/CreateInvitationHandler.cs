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
    public class CreateInvitationHandler : IRequestHandler<CreateInvitation, Invitation>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateInvitationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Invitation> Handle(CreateInvitation request, CancellationToken cancellationToken)
        {
            var sender = await _unitOfWork.UserRepository.GetUser(request.SenderId);
            var receiver = await _unitOfWork.UserRepository.GetUser(request.ReceiverId);
            var marathon = await _unitOfWork.MarathonRepository.GetMarathon(request.MarathonId);
            var invitation = new Invitation() { Sender = sender, Receiver = receiver, Marathon = marathon };

            await _unitOfWork.InvitationRepository.CreateInvitation(invitation);
            await _unitOfWork.Save();

            return invitation;
        }
    }
}
