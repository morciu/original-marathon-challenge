using Application.Abstract;
using Application.Marathons.Commands;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Marathons.CommandHandlers
{
    public class AddUserToMaratonCommandHandler : IRequestHandler<AddUserToMaratonCommand, Marathon>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddUserToMaratonCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Marathon> Handle(AddUserToMaratonCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetUser(request.UserId);
            var marathon = await _unitOfWork.MarathonRepository.GetMarathon(request.MarathonId);

            if (user == null || marathon == null) 
                return null;

            user.Marathons.Add(marathon);
            marathon.Members.Add(user);
            await _unitOfWork.Save();

            return marathon;
        }
    }
}
