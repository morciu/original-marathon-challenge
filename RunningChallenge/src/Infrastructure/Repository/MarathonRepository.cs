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
    public class MarathonRepository : IMarathonRepository
    {
        private readonly ApplicationDbContext _context;

        public MarathonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateMarathon(Marathon marathon)
        {
            await _context.Marathons.AddAsync(marathon);
        }

        public async void Delete(Marathon marathon)
        {
            _context.Marathons.Remove(marathon);
        }

        public async Task<List<Marathon>> GetAllMarathons()
        {
            var result = await _context.Marathons.Include(m => m.Members).ToListAsync();
            return result;
        }

        public async Task<List<User>> GetAllUsers(int id)
        {
            var result = await _context.Marathons.Where(m => m.Id == id).SelectMany(m => m.Members).ToListAsync();
            return result;
        }

        public async Task<List<User>> GetAllUsersByDistance(int id)
        {
            var members = await _context.Marathons
                .Where(m => m.Id == id)
                .SelectMany(m => m.Members)
                .OrderByDescending(m => m.Activities
                    .Select(a => a.Distance)
                    .Sum())
                .ToListAsync();

            return members;
        }

        public async Task<Marathon> GetMarathon(int id)
        {
            var result = await _context.Marathons.Include(m => m.Members).SingleAsync(m => m.Id == id);
            return result;
        }

        public async Task<int> CountMembers(Marathon marathon)
        {
            var mar = await _context.Marathons.SingleAsync(m => m == marathon);
            var result = mar.Members.Count();

            return result;
        }

        public async Task<decimal> AverageDistance(Marathon marathon)
        {
            /* var mar = await _context.Marathons.Include(m => m.Members).SingleAsync(m => m.Id == marathon.Id);
             var memberIds = mar.Members.Select(m => m.Id).ToList();
             var activities = await _context.Activities.Where(a => memberIds.Contains(a.UserId)).ToListAsync();
             var result = activities.Average(a => a.Distance);*/

            var result = await _context.Marathons
                .Include(m => m.Members)
                .ThenInclude(m => m.Activities)
                .SelectMany(m => m.Members)
                .SelectMany(m => m.Activities)
                .AverageAsync(x => x.Distance);

            return result;
        }

        public async Task<decimal> TotalUserDistance(int marathonId, int userId)
        {
            //var totalDistance = await _context.Marathons
            //    .Where(m => m.Id == marathonId)
            //    .SelectMany(u => u.Members
            //        .Where(m => m.Id == userId)
            //        .SelectMany(u => u.Activities
            //            .Select(a => a.Distance)
            //            )
            //        )
            //    .SumAsync();

            //return totalDistance;

            throw new NotImplementedException();
        }
    }
}
