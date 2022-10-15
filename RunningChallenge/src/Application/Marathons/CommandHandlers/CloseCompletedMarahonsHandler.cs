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
    public class CloseCompletedMarahonsHandler : IRequestHandler<CloseCompletedMarahons, List<Marathon>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CloseCompletedMarahonsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Marathon>> Handle(CloseCompletedMarahons request, CancellationToken cancellationToken)
        {
            var marathons = await _unitOfWork.MarathonRepository.GetAllMarathonsWithUserRaw(request.UserId);

            foreach(var marathon in marathons)
            {
                int finishedMembers = 0;
                foreach (var member in marathon.Members)
                {
                    bool finished = false;
                    foreach(var medal in member.Medals)
                    {
                        if(medal.MarathonId == marathon.Id)
                        {
                            finishedMembers++;
                            finished = true;
                            break;
                        }
                    }
                    if (!finished) break;
                }
                if(finishedMembers == marathon.Members.Count())
                {
                    marathon.IsDone = true;
                }
            }
            await _unitOfWork.Save();

            return marathons;
        }
    }
}
