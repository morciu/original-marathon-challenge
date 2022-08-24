using Application.Abstract;
using Domain.Models;
using MediatR;

namespace Application.Users.Commands.CreateUser
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
            var user = new User { FirstName = request.FirstName, LastName = request.LastName, UserName = request.UserName, Password = request.Password};

            await _unitOfWork.UserRepository.CreateUser(user);
            await _unitOfWork.Save();

            return user;
        }
        /*
       public Task<User> Handle(CreateUserCommand message, CancellationToken cancellationToken)
       {
          *//* int nextId;
           try { nextId = _userRepository.GetNextUserId(); }
           catch (FileNotFoundException) { nextId = 0; }
           var user = new User(nextId, message.FirstName, message.LastName, message.UserName, message.Password);
           _userRepository.CreateUser(user);


           return Task.FromResult(user);*//*
       }*/
    }
}
