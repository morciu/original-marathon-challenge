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
    public class CountUserActivitiesQueryHandler : IRequestHandler<CountUserActivitiesQuery, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CountUserActivitiesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CountUserActivitiesQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ActivityRepository.CountUserActivities(request.Id);
        }
    }
}
