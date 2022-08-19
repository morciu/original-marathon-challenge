using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Activities.Queries.GetActivity
{
    internal class GetAllUserActivitiesQueryHandler : IRequestHandler<GetAllUserActivitiesQuery, List<Activity>>
    {
        private readonly IActivityRepository _activityRepository;
        public GetAllUserActivitiesQueryHandler(IActivityRepository repo)
        {
            _activityRepository = repo;
        }
        public Task<List<Activity>> Handle(GetAllUserActivitiesQuery request, CancellationToken cancellationToken)
        {
            List<Activity> result = _activityRepository.GetUserActivities(request.UserId);

            return Task.FromResult(result);
        }
    }
}
