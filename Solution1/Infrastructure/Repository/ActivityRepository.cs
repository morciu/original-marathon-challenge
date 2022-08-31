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
    public class ActivityRepository : IActivityRepository
    {
        private readonly DataContext _context;
        public ActivityRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task CreateActivity(Activity activity)
        {
            await _context.Activities.AddAsync(activity);
        }

        public void Delete(Activity activity)
        {
            _context.Activities.Remove(activity);
        }

        public async Task<Activity> GetActivityById(int id)
        {
            var result = await _context.Activities.FindAsync(id);
            return result;
        }

        public async Task<List<Activity>> GetAllActivities()
        {
            var activities = await _context.Activities.ToListAsync();
            return activities;
        }

        public async Task<List<Activity>> GetUserActivities(int userId)
        {
            var activities = await _context.Activities.Where(a => a.UserId == userId).ToListAsync();

            return activities;
        }
    }
}
