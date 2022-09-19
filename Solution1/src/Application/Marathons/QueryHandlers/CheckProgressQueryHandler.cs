using Application.Abstract;
using Application.Marathons.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Marathons.QueryHandlers
{
    public class CheckProgressQueryHandler : IRequestHandler<CheckProgressQuery, decimal>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CheckProgressQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<decimal> Handle(CheckProgressQuery request, CancellationToken cancellationToken)
        {
            decimal marathonDistance = 240m;
            var totalDistance = await _unitOfWork.MarathonRepository.TotalUserDistance(request.MarathonId, request.UserId);
            var result = Decimal.Round(totalDistance / marathonDistance * 100, 2);

            return result;
        }
    }
}
