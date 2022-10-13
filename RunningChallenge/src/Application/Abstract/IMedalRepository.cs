using Domain.Models;
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
        Task<List<Medal>> GetAllMedals(int userId);
        Task<List<Medal>> GetUserMedalsInMarathon(int userId, int marathonId);
    }
}
