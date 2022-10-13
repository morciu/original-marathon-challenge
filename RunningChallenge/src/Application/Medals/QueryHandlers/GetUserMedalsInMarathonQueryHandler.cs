using Application.Abstract;
using Application.Medals.Queries;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Medals.QueryHandlers
{
    public class GetUserMedalsInMarathonQueryHandler : IRequestHandler<GetUserMedalsInMarathonQuery, List<Medal>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserMedalsInMarathonQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Medal>> Handle(GetUserMedalsInMarathonQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.MedalRepository.GetUserMedalsInMarathon(request.UserId, request.MarathonId);
            
            return result;
        }
    }
}
