using Application.Abstract;
using Application.Likes.Commands;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Likes.CommandHandlers
{
    public class CreateLikeCommandHandler : IRequestHandler<CreateLikeCommand, Like>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateLikeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Like> Handle(CreateLikeCommand request, CancellationToken cancellationToken)
        {
            var sender = await _unitOfWork.UserRepository.GetUser(request.SenderId);
            var activity = await _unitOfWork.ActivityRepository.GetActivityById(request.ActivityId);

            if (sender == null || activity == null) return null;

            var like = new Like { Activity=activity, ActivityId=activity.Id, Sender=sender, SenderId=sender.Id };

            await _unitOfWork.LikeRepository.CreateLike(like);
            await _unitOfWork.Save();

            return like;
        }
    }
}
