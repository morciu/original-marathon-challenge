using Application.Abstract;
using Application.Marathons.Queries;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Marathons.QueryHandlers
{
    public class GetAllMembersQueryHandler : IRequestHandler<GetAllMembersQuery, List<User>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllMembersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<List<User>> Handle(GetAllMembersQuery request, CancellationToken cancellationToken)
        {
            var result = _unitOfWork.MarathonRepository.GetAllUsers(request.Id);

            return result;
        }
    }
}
