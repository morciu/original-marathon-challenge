using Domain.Models;
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
        Task<Marathon> GetMarathon(int id);
        Task<List<User>> GetAllUsers();
        Task<List<User>> GetAllUsersByDistance();
    }
}
