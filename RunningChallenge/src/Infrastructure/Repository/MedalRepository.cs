using Application.Abstract;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class MedalRepository : IMedalRepository
    {
        private readonly ApplicationDbContext _context;

        public MedalRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateMedal(Medal medal)
        {
            await _context.Medals.AddAsync(medal);
        }
    }
}
