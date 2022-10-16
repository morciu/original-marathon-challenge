using Application.Abstract;
using Application.Users.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.QueryHandlers
{
    public class CountAllUsersQueryHandler : IRequestHandler<CountAllUsersQuery, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CountAllUsersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CountAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.UserRepository.CountAllUsers();
        }
    }
}
