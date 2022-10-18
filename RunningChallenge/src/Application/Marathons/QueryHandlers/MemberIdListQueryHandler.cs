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
    public class MemberIdListQueryHandler : IRequestHandler<MemberIdListQuery, List<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public MemberIdListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<int>> Handle(MemberIdListQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.MarathonRepository.GetMemberIdList(request.Id);
            return result;
        }
    }
}
