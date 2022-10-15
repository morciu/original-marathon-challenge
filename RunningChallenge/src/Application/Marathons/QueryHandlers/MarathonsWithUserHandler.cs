using Application.Abstract;
using Application.Marathons.Queries;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Marathons.QueryHandlers
{
    public class MarathonsWithUserHandler : IRequestHandler<MarathonsWithUser, List<Marathon>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public MarathonsWithUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Marathon>> Handle(MarathonsWithUser request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.MarathonRepository.GetAllMarathonsWithUser(request.UserId, request.PageNr, request.PageSize, request.FilterWord);

            return result;
        }
    }
}
