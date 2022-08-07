using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUser
{
    internal class GetUserQueryCommandHandler : IRequestHandler<GetUserQueryCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserQueryCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> Handle(GetUserQueryCommand request, CancellationToken cancellationToken)
        {

            User result = _userRepository.GetUser(request.Id);

            return Task.FromResult(result);
        }
    }
}
