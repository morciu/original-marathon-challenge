using Application.Abstract;
using Application.Activities.Commands;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Activities.CommandHandlers
{
    internal class CreateActivityCommandHandler : IRequestHandler<CreateActivityCommand, Activity>
    {
        IUnitOfWork _unitOfWork;
        public CreateActivityCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Activity> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
        {
            var activity = new Activity { UserId = request.RunnerId, Distance = request.Distance, Date = request.Date, Duration = request.Duration };
            activity.Pace = activity.CalculatePace(activity.Distance, activity.Duration);

            await _unitOfWork.ActivityRepository.CreateActivity(activity);
            await _unitOfWork.Save();

            return activity;
        }
    }
}
