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
    public class InvitationRepository : IInvitationRepository
    {
        private readonly ApplicationDbContext _context;
        public InvitationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Invitation>> CheckUnansweredInvitations(User receiver)
        {
            var result = await _context.Invitations
                .Where(i => i.Receiver.Id == receiver.Id)
                .Where(i => i.IsActive == true)
                .ToListAsync();

            return result;
        }

        public async Task CreateInvitation(Invitation invitation)
        {
            await _context.Invitations.AddAsync(invitation);
        }
    }
}
