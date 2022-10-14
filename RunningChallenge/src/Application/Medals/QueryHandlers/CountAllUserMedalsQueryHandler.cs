using Application.Abstract;
using Application.Medals.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Medals.QueryHandlers
{
    public class CountAllUserMedalsQueryHandler : IRequestHandler<CountAllUserMedalsQuery, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CountAllUserMedalsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CountAllUserMedalsQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.MedalRepository.CountAllUserMedals(request.UserId);
        }
    }
}
