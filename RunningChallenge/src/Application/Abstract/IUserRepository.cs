using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Abstract
{
    public interface IUserRepository
    {
        Task CreateUser(User user);
        public void Delete(User user);
        Task<User> GetUser(int userId);
        Task<User> GetUserByLogin(string userName, string password);
        void UpdateUserActivity(int id, string field, string value);
        Task<Dictionary<string, string>> GetUserActivityInfo(int Id);
        Task<List<User>> GetAll(int pageNr, int pageSize);
        Task<TimeSpan> GetTotalTime(int userId);
        Task<User> UpdateUserMarathonStatus(int userId);
    }
}
