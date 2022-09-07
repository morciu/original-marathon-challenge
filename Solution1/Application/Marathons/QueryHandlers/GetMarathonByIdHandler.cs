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
    public class GetMarathonByIdHandler : IRequestHandler<GetMarathonByIdCommand, Marathon>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMarathonByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Marathon> Handle(GetMarathonByIdCommand request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.MarathonRepository.GetMarathon(request.Id);
        }
    }
}
