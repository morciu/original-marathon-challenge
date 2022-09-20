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
    public class DeleteActivityHandler : IRequestHandler<DeleteActivity, Activity>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteActivityHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Activity> Handle(DeleteActivity request, CancellationToken cancellationToken)
        {
            var activity = await _unitOfWork.ActivityRepository.GetActivityById(request.Id);
            _unitOfWork.ActivityRepository.Delete(activity);
            await _unitOfWork.Save();
            return activity;
        }
    }
}
