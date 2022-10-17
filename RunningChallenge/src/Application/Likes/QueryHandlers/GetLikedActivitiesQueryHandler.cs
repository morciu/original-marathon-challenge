using Application.Abstract;
using Application.Likes.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Likes.QueryHandlers
{
    public class GetLikedActivitiesQueryHandler : IRequestHandler<GetLikedActivitiesQuery, List<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetLikedActivitiesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<int>> Handle(GetLikedActivitiesQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.LikeRepository.GetLikedActivities(request.UserId);
            return result;
        }
    }
}
