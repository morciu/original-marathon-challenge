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
    public class GetAllActivitiesQueryHandler : IRequestHandler<GetAllActivitiesQuery, List<Activity>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllActivitiesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Activity>> Handle(GetAllActivitiesQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ActivityRepository.GetAllActivities();
        }
    }
}
