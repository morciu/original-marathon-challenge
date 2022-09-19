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
    public class GetUserByIdQueryCommandHandler : IRequestHandler<GetUserByIdQueryCommand, User>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserByIdQueryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> Handle(GetUserByIdQueryCommand request, CancellationToken cancellationToken)
        {

            var result = await _unitOfWork.UserRepository.GetUser(request.Id);

            return result;
        }
    }
}
