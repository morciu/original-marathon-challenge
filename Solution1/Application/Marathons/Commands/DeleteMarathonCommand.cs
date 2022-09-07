using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Marathons.Commands
{
    public class DeleteMarathonCommand : IRequest<Marathon>
    {
        public int Id { get; set; }
    }
}
