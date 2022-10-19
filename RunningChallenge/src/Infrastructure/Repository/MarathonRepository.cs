using Application.Abstract;
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

        public async Task<List<User>> GetAllUsers(int id, int pageNr, int pageSize)
        {
            var result = await _context.Marathons
                .Where(m => m.Id == id)
                .SelectMany(m => m.Members)
                .Skip((pageNr - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return result;
        }

        public async Task<List<User>> GetAllUsersByDistance(int id, int pageNr, int pageSize)
        {
            var marathon = await _context.Marathons.FindAsync(id);

            var members = await _context.Marathons
                .Where(m => m.Id == id)
                .Include(m => m.Members)
                .ThenInclude(m => m.Activities.Where(a => a.Date >= marathon.StartDate))
                .Include(m => m.Members)
                .ThenInclude(m => m.Marathons)
                .SelectMany(m => m.Members)
                .OrderByDescending(m => m.Activities.Where(a => a.Date >= marathon.StartDate)
                    .Select(a => a.Distance)
                    .Sum())
                .Skip((pageNr - 1) * pageSize)
                .Take(pageSize)
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
            var marathon = await _context.Marathons.FindAsync(marathonId);

            var totalDistance = await _context.Marathons
                .Where(m => m.Id == marathonId)
                .SelectMany(u => u.Members
                    .Where(m => m.Id == userId)
                    .SelectMany(u => u.Activities.Where(a => a.Date >= marathon.StartDate)
                        .Select(a => a.Distance)
                        )
                    )
                .SumAsync();

            return totalDistance;
        }

        public async Task<List<Marathon>> GetAllMarathonsWithUser(int userId, int pageNr, int pageSize, string filter="all")
        {
            var user = await _context.Users.FindAsync(userId);
            var result = new List<Marathon>();

            if (filter == "all")
            {
                result = await _context.Marathons
                .Where(m => m.Members.Contains(user))
                .Skip((pageNr - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            } else if (filter == "active") {
                result = await _context.Marathons
                .Where(m => m.Members.Contains(user) && m.IsDone == false)
                .Skip((pageNr - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            } else if (filter == "finished")
            {
                result = await _context.Marathons
                .Where(m => m.Members.Contains(user) && m.IsDone == true)
                .Skip((pageNr - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            }

            return result;
        }

        public async Task<List<Marathon>> GetAllMarathonsWithUserRaw(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            var marathons = await _context.Marathons
                .Where(m => m.Members.Contains(user))
                .Include(m => m.Members)
                .ThenInclude(u => u.Medals)
                .ToListAsync();

            return marathons;
        }

        public async Task<List<int>> GetMemberIdList(int marathonId)
        {
            var marathon = await _context.Marathons.FindAsync(marathonId);
            var result = marathon?.Members.Select(m => m.Id).ToList();
            return result;
        }
    }
}
