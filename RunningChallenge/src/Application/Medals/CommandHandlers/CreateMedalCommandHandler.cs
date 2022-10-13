using Application.Abstract;
using Application.Medals.Commands;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Medals.CommandHandlers
{
    public class CreateMedalCommandHandler : IRequestHandler<CreateMedalCommand, Medal>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateMedalCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Medal> Handle(CreateMedalCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetUser(request.UserId);

            var activities = await _unitOfWork.ActivityRepository.GetUserActivitiesInMarathonRaw(request.UserId, request.MarathonId);
            var totalTime = new TimeSpan(activities.Sum(a => a.Duration.Ticks));
            var pace = TimeSpan.FromSeconds(
                Math.Round(totalTime.TotalSeconds / Convert.ToDouble(240m))
                );

            var marathon = await _unitOfWork.MarathonRepository.GetMarathon(request.MarathonId);

            var medal = new Medal { Date = DateTime.Now, 
                UserId = request.UserId, 
                User = user, 
                MarathonId = request.MarathonId, 
                Marathon = marathon, 
                Time = totalTime,
                Pace = pace};

            if (medal == null || user == null || activities == null || marathon == null) { return null; };

            await _unitOfWork.MedalRepository.CreateMedal(medal);
            await _unitOfWork.Save();

            return medal;
        }
    }
}
