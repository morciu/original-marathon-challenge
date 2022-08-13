using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Activities.Commands.CreateActivity
{
    internal class CreateActivityCommandHandler : IRequestHandler<CreateActivityCommand, Activity>
    {
        IActivityRepository _repo;
        public CreateActivityCommandHandler(IActivityRepository repo)
        {
            _repo = repo;
        }

        public Task<Activity> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
        {
            Activity activity = new Activity(request.RunnerId, request.Distance, request.Date, request.Duration);
            _repo.CreateActivity(request.RunnerId.ToString(), request.Distance.ToString(), request.Date.ToString(), request.Duration.ToString());

            throw new NotImplementedException();
        }
    }
}
