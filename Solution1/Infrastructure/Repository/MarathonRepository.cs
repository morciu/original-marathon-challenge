﻿using Application.Abstract;
using Domain.Models;
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

        public Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllUsersByDistance()
        {
            throw new NotImplementedException();
        }

        public async Task<Marathon> GetMarathon(int id)
        {
            var result = await _context.Marathons.FindAsync(id);
            return result;
        }
    }
}
