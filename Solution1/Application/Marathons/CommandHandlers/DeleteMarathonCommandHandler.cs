using Application.Abstract;
using Application.Marathons.Commands;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Marathons.CommandHandlers
{
    public class DeleteMarathonCommandHandler : IRequestHandler<DeleteMarathonCommand, Marathon>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMarathonCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Marathon> Handle(DeleteMarathonCommand request, CancellationToken cancellationToken)
        {
            var marathon = await _unitOfWork.MarathonRepository.GetMarathon(request.Id);
            if (marathon == null) return null;

            _unitOfWork.MarathonRepository.Delete(marathon);
            await _unitOfWork.Save();

            return marathon;
        }
    }
}
