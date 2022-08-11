using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.UpdateUser
{
    internal class UpdateUserActivityCommandHandler : IRequestHandler<UpdateUserActivityCommand, bool>
    {
        private readonly IUserRepository _repository;
        public UpdateUserActivityCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        Task<bool> IRequestHandler<UpdateUserActivityCommand, bool>.Handle(UpdateUserActivityCommand request, CancellationToken cancellationToken)
        {
            _repository.UpdateUserActivity(request.Id, request.Field, request.Value);
            return Task.FromResult(true);
        }
    }
}
