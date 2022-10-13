using Application.Abstract;
using Application.Medals.Commands;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Medals.CommandHandlers
{
    public class DeleteMedalCommandHandler : IRequestHandler<DeleteMedalCommand, Medal>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMedalCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Medal> Handle(DeleteMedalCommand request, CancellationToken cancellationToken)
        {
            var medal = await _unitOfWork.MedalRepository.GetMedal(request.Id);
            if(medal == null) return null;

            _unitOfWork.MedalRepository.Delete(medal);
            await _unitOfWork.Save();

            return medal;
        }
    }
}
