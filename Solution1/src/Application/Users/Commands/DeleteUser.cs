using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands
{
    public class DeleteUser : IRequest<User>
    {
        public int Id { get; set; }
    }
}
