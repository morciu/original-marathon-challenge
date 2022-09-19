using Application.Abstract;
using Application.Activities.Commands;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Activities.CommandHandlers
{
    public class AddActivityToUserHandler : IRequestHandler<AddActivityToUser, User>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddActivityToUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> Handle(AddActivityToUser request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetUser(request.UserId);
            var activity = await _unitOfWork.ActivityRepository.GetActivityById(request.ActivityId);

            if (activity == null || user == null)
                return null;

            user.Activities.Add(activity);
            await _unitOfWork.Save();

            return user;
        }
    }
}
