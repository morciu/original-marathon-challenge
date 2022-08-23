using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUser
{
    public class GetUserByIdQueryCommandHandler : IRequestHandler<GetUserByIdQueryCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> Handle(GetUserByIdQueryCommand request, CancellationToken cancellationToken)
        {

            User result = _userRepository.GetUser(request.Id);

            return Task.FromResult(result);
        }
    }
}
