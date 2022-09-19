using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Marathons.Commands
{
    public class AddUserToMaratonCommand : IRequest<Marathon>
    {
        public int UserId { get; set; }
        public int MarathonId { get; set; }
    }
}
