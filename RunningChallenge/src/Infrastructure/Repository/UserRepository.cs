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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task<List<User>> GetAll(int pageNr, int pageSize)
        {
            var result = await _context.Users.Include(u => u.Activities)
                .Skip((pageNr - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return result;
        }

        public async Task<TimeSpan> GetTotalTime(int userId)
        {
            var activityTimes = await _context.Activities.Where(a => a.UserId == userId).Select(a => a.Duration).ToListAsync();
            var result = new TimeSpan(activityTimes.Sum(t => t.Ticks));

            return result;
        }

        public async Task<User> GetUser(int userId)
        {
            var user = await _context.Users
                .Include(u => u.Activities)
                .Include(u => u.Marathons)
                .SingleAsync(u => u.Id == userId);

            user.TotalDistance = user.CalculateTotalDistance();
            user.AveragePace = user.CalculateAveragePace();

            return user;
        }

        public async Task<Dictionary<string, string>> GetUserActivityInfo(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByLogin(string userName, string password)
        {
            /*var user = await _context.Users
                .SingleOrDefaultAsync(u => u.UserName == userName && u.Password == password);

            return user;*/
            throw new NotImplementedException();
        }

        public void UpdateUserActivity(int id, string field, string value)
        {
            throw new NotImplementedException();
        }

        public async Task<User> UpdateUserMarathonStatus(int userId)
        {
            /*var user = await _context.Users
                .Include(u => u.Activities)
                .Include(u => u.Marathons)
                .SingleAsync(u => u.Id == userId);

            foreach(var marathon in user.Marathons)
            {
                decimal totalDist = 0;

                foreach(var activity in user.Activities)
                {
                    if (activity.Date >= marathon.StartDate)
                    {
                        totalDist += activity.Distance;
                    }
                    if (totalDist >= 240m)
                    {

                    }
                }
            }*/

            throw new NotImplementedException();
        }
    }
}
