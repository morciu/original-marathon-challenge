﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstract
{
    public interface IMarathonRepository
    {
        Task CreateMarathon(Marathon marathon);
        void Delete(Marathon marathon);
        Task<Marathon> GetMarathon(int id);
        Task<List<Marathon>> GetAllMarathons();
        Task<List<User>> GetAllUsers(int id, int pageNr, int pageSize);
        Task<List<User>> GetAllUsersByDistance(int id, int pageNr, int pageSize);
        Task<int> CountMembers(Marathon marathon);
        Task<decimal> AverageDistance(Marathon marathon);
        Task<decimal> TotalUserDistance(int marathonId, int userId);
        Task<List<Marathon>> GetAllMarathonsWithUser(int userId, int pageNr, int pageSize, string filter="all");
        Task<List<Marathon>> GetAllMarathonsWithUserRaw(int userId);
        Task<List<int>> GetMemberIdList(int marathonId);
    }
}
