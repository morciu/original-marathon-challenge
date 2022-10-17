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
    public class DeleteLikeCommandHandler : IRequestHandler<DeleteLikeCommand, Like>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteLikeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Like> Handle(DeleteLikeCommand request, CancellationToken cancellationToken)
        {
            var like = await _unitOfWork.LikeRepository.DeleteLike(request.ActivityId, request.SenderId);
            await _unitOfWork.Save();
            return like;
        }
    }
}
