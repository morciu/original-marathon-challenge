using Application.Abstract;
using Application.Users.Commands;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.CommandHandlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUser, User>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> Handle(DeleteUser request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetUser(request.Id);
            if (user == null)
                return null;
            _unitOfWork.UserRepository.Delete(user);
            await _unitOfWork.Save();

            return user;
        }
    }
}
