﻿using Application.Abstract;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class LikeRepository : ILikeRepository
    {
        private readonly ApplicationDbContext _context;

        public LikeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateLike(Like like)
        {
            await _context.Likes.AddAsync(like);
        }

        public async Task<Like> DeleteLike(int activityId, int senderId)
        {
            var like = await _context.Likes.Where(l => l.ActivityId == activityId && l.SenderId == senderId).FirstOrDefaultAsync();
            _context.Remove(like);
            return like;
        }

        public async Task<Like> GetLikeById(int likeId)
        {
            return await _context.Likes.FindAsync(likeId);
        }

        public async Task<List<int>> GetLikedActivities(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            var result = await _context.Likes.Where(l => l.Sender == user).Select(l => l.ActivityId).ToListAsync();

            return result;
        }
    }
}
