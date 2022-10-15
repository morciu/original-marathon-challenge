using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Marathons.Commands
{
    public class CloseCompletedMarahons : IRequest<List<Marathon>>
    {
        public int UserId { get; set; }
    }
}
