using Application.Abstract;
using Application.Users.Commands;
using Domain.Models;
using MediatR;

namespace Application.Users.CommandHandlers
{
    internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            //var user = new User { FirstName = request.FirstName, LastName = request.LastName, UserName = request.UserName, Password = request.Password };

            //await _unitOfWork.UserRepository.CreateUser(user);
            //await _unitOfWork.Save();

            //return user;

            throw new NotImplementedException();
        }
    }
}
