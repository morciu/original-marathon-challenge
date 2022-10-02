using MediatR;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Invitations.Commands
{
    public class CreateInvitation : IRequest<Invitation>
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public int MarathonId { get; set; }
    }
}
