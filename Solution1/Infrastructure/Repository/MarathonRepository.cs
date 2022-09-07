using Application.Abstract;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class MarathonRepository : IMarathonRepository
    {
        private readonly DataContext _context;

        public MarathonRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateMarathon(Marathon marathon)
        {
            await _context.Marathons.AddAsync(marathon);
        }

        public async void Delete(Marathon marathon)
        {
            _context.Marathons.Remove(marathon);
        }

        public async Task<List<Marathon>> GetAllMarathons()
        {
            var result = await _context.Marathons.Include(m => m.Members).ToListAsync();
            return result;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var result = await _context.Marathons.SelectMany(m => m.Members).ToListAsync();
            return result;
        }

        public Task<List<User>> GetAllUsersByDistance()
        {
            throw new NotImplementedException();
        }

        public async Task<Marathon> GetMarathon(int id)
        {
            var result = await _context.Marathons.Include(m => m.Members).FirstAsync();
            return result;
        }
    }
}
