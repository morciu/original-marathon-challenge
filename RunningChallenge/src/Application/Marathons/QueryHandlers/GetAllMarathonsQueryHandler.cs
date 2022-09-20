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
    public class GetAllMarathonsQueryHandler : IRequestHandler<GetAllMarathonsQuery, List<Marathon>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllMarathonsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Marathon>> Handle(GetAllMarathonsQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.MarathonRepository.GetAllMarathons();
        }
    }
}
