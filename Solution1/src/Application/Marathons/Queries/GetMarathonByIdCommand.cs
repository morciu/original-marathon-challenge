using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Marathons.Queries
{
    public class GetMarathonByIdCommand : IRequest<Marathon>
    {
        public int Id { get; set; }
    }
}
