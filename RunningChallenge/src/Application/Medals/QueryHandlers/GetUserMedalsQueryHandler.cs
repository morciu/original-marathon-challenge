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
    public class GetUserMedalsQueryHandler : IRequestHandler<GetUserMedalsQuery, List<Medal>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserMedalsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Medal>> Handle(GetUserMedalsQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.MedalRepository.GetAllMedals(request.UserId, request.PageNr, request.PageSize);
        }
    }
}
