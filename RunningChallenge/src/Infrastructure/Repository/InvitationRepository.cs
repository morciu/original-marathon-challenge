using Application.Abstract;
using Domain.Models;
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
        public async Task CreateInvitation(Invitation invitation)
        {
            await _context.Invitations.AddAsync(invitation);
        }
    }
}
