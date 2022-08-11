using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.UpdateUser
{
    public class UpdateUserActivityCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Field { get; set; }
        public string Value { get; set; }
    }
}
