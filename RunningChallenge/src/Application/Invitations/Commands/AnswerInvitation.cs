using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Invitations.Commands
{
    public class AnswerInvitation : IRequest<Invitation>
    {
        public int InvitationId { get; set; }
        public bool Answer { get; set; }
    }
}
