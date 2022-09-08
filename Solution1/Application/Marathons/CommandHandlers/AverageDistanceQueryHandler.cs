using Application.Abstract;
using Application.Marathons.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Marathons.CommandHandlers
{
    public class AverageDistanceQueryHandler : IRequestHandler<AverageDistanceQuery, decimal>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AverageDistanceQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<decimal> Handle(AverageDistanceQuery request, CancellationToken cancellationToken)
        {
            var marathon = await _unitOfWork.MarathonRepository.GetMarathon(request.Id);
            var result = await _unitOfWork.MarathonRepository.AverageDistance(marathon);
            return result;
        }
    }
}
