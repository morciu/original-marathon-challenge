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
    public class CreateMarathonHandler : IRequestHandler<CreateMarathonCommand, Marathon>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateMarathonHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Marathon> Handle(CreateMarathonCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetUser(request.FirstMemberId);
            var marathon = new Marathon { StartDate = DateTime.Now, Members = new List<User>() };

            if (marathon == null || user == null)
                return null;

            marathon.Members.Add(user);

            await _unitOfWork.MarathonRepository.CreateMarathon(marathon);
            await _unitOfWork.Save();

            return marathon;
        }
    }
}
