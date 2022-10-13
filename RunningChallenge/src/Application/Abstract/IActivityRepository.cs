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
        public void Delete(Activity activity);
        Task<List<Activity>> GetUserActivities(int userId, int pageNr, int pageSize);
        Task<List<Activity>> GetAllActivities();
        Task<Activity> GetActivityById(int id);
        Task<int> CountUserActivities(int id);
        Task<List<Activity>> GetUserActivitiesInMarathonRaw(int userId, int marathonId);
    }
}
