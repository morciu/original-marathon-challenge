using Domain;
using MediatR;

namespace Application.Users.Commands.CreateUser
{
    internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<int> Handle(CreateUserCommand message, CancellationToken cancellationToken)
        {
            var user = new User(message.Id, message.FirstName, message.LastName, message.UserName, message.Password);

            return Task.FromResult(user.ID);
        }
    }
}
