using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUser
{
    internal class GetUserQueryLoginHandler : IRequestHandler<GetUserQueryLoginCommand, User>
    {
        private readonly IUserRepository _userRepository;
        public GetUserQueryLoginHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> Handle(GetUserQueryLoginCommand request, CancellationToken cancellationToken)
        {
            User result = _userRepository.GetUserByLogin(request.UserName, request.Password);
            return Task.FromResult(result);
        }
    }
}
