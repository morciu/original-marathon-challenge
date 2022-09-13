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
    public class UsersByDistanceQueryHandler : IRequestHandler<UsersByDistanceQuery, List<User>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersByDistanceQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<User>> Handle(UsersByDistanceQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.MarathonRepository.GetAllUsersByDistance(request.Id);

            return result;
        }
    }
}
