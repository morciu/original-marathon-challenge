using Application.Abstract;
using Application.Users.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.QueryHandlers
{
    public class GetTotalTimeQueryHandler : IRequestHandler<GetTotalTime, TimeSpan>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTotalTimeQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<TimeSpan> Handle(GetTotalTime request, CancellationToken cancellationToken)
        {
            var result = _unitOfWork.UserRepository.GetTotalTime(request.Id);
            return result;
        }
    }
}
