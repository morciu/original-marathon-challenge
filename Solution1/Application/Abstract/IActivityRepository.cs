using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstract
{
    public interface IActivityRepository
    {
        Task CreateActivity(Activity activity);
        Task<List<Activity>> GetUserActivities(int userId);
        Task<List<Activity>> GetAllActivities();
        Task<Activity> GetActivityById(int id);
    }
}
