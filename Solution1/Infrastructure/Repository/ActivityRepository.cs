using Application.Abstract;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly DataContext _dataContext;
        public ActivityRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void CreateActivity(string id, string distance, string date, string duration)
        {
            throw new NotImplementedException();
        }

        public List<Activity> GetUserActivities(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
