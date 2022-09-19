using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Activities.Commands
{
    public class AddActivityToUser : IRequest<User>
    {
        public int UserId { get; set; }
        public int ActivityId { get; set; }
    }
}
