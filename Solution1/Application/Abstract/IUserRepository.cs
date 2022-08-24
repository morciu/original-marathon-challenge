﻿using System;
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
        User GetUser(int userId);
        User GetUserByLogin(string userName, string password);
        int GetNextUserId();
        void UpdateUserActivity(int id, string field, string value);
        Dictionary<string, string> GetUserActivityInfo(int Id);
    }
}
