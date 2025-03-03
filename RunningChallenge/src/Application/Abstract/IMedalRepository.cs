﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstract
{
    public interface IMedalRepository
    {
        Task CreateMedal(Medal medal);
        void Delete(Medal medal);
        Task<List<Medal>> GetAllMedals(int userId, int pageNr, int pageSize);
        Task<List<Medal>> GetUserMedalsInMarathon(int userId, int marathonId);
        Task<Medal> GetMedal(int id);
        Task<bool> CheckIfMedalExistsForMarathon(int userId, int marathonId);
        Task<int> CountAllUserMedals(int userId);
    }
}
