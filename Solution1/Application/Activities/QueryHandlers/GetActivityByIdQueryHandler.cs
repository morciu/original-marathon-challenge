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
    internal class GetActivityByIdQueryHandler : IRequestHandler<GetActivityByIdQuery, Activity>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetActivityByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Activity> Handle(GetActivityByIdQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ActivityRepository.GetActivityById(request.Id);
        }
    }
}
