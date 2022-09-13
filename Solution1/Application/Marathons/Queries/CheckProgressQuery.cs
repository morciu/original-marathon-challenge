using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Marathons.Queries
{
    public class CheckProgressQuery : IRequest<decimal>
    {
        public int MarathonId { get; set; }
        public int UserId { get; set; }
    }
}
