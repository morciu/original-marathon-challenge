using Application.Abstract;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public int GetNextUserId()
        {
            throw new NotImplementedException();
        }

        public User GetUser(int userId)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetUserActivityInfo(int Id)
        {
            throw new NotImplementedException();
        }

        public User GetUserByLogin(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserActivity(int id, string field, string value)
        {
            throw new NotImplementedException();
        }
    }
}
