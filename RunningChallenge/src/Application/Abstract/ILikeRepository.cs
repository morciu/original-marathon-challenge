using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstract
{
    public interface ILikeRepository
    {
        Task CreateLike(Like like);
        Task<List<int>> GetLikedActivities(int userId);
        Task<Like> GetLikeById(int likeId);
        Task<Like> DeleteLike(int activityId, int senderId);
    }
}
