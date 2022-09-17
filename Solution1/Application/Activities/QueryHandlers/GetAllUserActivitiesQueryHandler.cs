using Application.Abstract;
using Application.Activities.Queries;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Activities.QueryHandlers
{
    public class GetAllUserActivitiesQueryHandler : IRequestHandler<GetAllUserActivitiesQuery, List<Activity>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllUserActivitiesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Activity>> Handle(GetAllUserActivitiesQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ActivityRepository.GetUserActivities(request.UserId);

            return result;
        }
    }
}
