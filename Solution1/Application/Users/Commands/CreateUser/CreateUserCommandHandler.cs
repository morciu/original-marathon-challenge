using Domain;
using MediatR;

namespace Application.Users.Commands.CreateUser
{
    internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> Handle(CreateUserCommand message, CancellationToken cancellationToken)
        {
            int nextId;
            try { nextId = _userRepository.GetNextUserId(); }
            catch (FileNotFoundException) { nextId = 0; }
            var user = new User(nextId, message.FirstName, message.LastName, message.UserName, message.Password);
            _userRepository.CreateUser(user);


            return Task.FromResult(user);
        }
    }
}
