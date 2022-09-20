using Application.Abstract;
using Application.Users.Queries;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.QueryHandlers
{
    internal class GetUserQueryLoginHandler : IRequestHandler<GetUserQueryLoginCommand, User>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetUserQueryLoginHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> Handle(GetUserQueryLoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetUserByLogin(request.UserName, request.Password);

            return user;
        }
    }
}
