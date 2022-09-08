using Application.Abstract;
using Application.Marathons.Queries;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Marathons.CommandHandlers
{
    public class CountMembersQueryHandler : IRequestHandler<CountMembersQuery, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CountMembersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CountMembersQuery request, CancellationToken cancellationToken)
        {
            var marathon = await _unitOfWork.MarathonRepository.GetMarathon(request.Id);
            var result = await _unitOfWork.MarathonRepository.CountMembers(marathon);

            return result;
        }
    }
}
