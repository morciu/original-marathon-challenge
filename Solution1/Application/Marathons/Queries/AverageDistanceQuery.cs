using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Marathons.Queries
{
    public class AverageDistanceQuery : IRequest<decimal>
    {
        public int Id { get; set; } 
    }
}
