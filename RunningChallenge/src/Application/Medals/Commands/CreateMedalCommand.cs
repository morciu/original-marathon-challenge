using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Medals.Commands
{
    public class CreateMedalCommand : IRequest<Medal>
    {
        public int UserId { get; set; }
        public int MarathonId { get; set; }
    }
}
