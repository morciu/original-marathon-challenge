using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IActivityRepository
    {
        void CreateActivity(string id, string distance, string date, string duration);
        List<Activity> GetUserActivities(int userId);
    }
}
