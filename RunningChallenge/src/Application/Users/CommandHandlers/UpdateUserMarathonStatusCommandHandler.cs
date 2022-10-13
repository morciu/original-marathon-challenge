using Application.Abstract;
using Application.Users.Commands.UpdateUser;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.CommandHandlers
{
    public class UpdateUserMarathonStatusCommandHandler : IRequestHandler<UpdateUserMarathonStatusCommand, User>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserMarathonStatusCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> Handle(UpdateUserMarathonStatusCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetUser(request.Id);

            if (user == null) return null;

            foreach (var marathon in user.Marathons)
            {
                decimal totalDist = 0;

                foreach (var activity in user.Activities)
                {
                    var activities = new List<Activity>();
                    if (activity.Date >= marathon.StartDate)
                    {
                        totalDist += activity.Distance;
                        activities.Add(activity);
                    }
                    if (totalDist >= 240m)
                    {
                        if(!await _unitOfWork.MedalRepository.CheckIfMedalExistsForMarathon(request.Id, marathon.Id))
                        {
                            var totalTime = new TimeSpan(activities.Sum(a => a.Duration.Ticks));
                            var pace = TimeSpan.FromSeconds(Math.Round(totalTime.TotalSeconds / 240));

                            var medal = new Medal
                            {
                                Date = DateTime.Now,
                                UserId = request.Id,
                                User = user,
                                MarathonId = marathon.Id,
                                Marathon = marathon,
                                Time =  totalTime,
                                Pace = pace
                            };

                            await _unitOfWork.MedalRepository.CreateMedal(medal);
                            await _unitOfWork.Save();
                        }
                        break;
                    }
                   
                }
            }
            

            return user;
        }
    }
}
