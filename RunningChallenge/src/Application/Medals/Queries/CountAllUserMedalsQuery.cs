using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Medals.Queries
{
    public class CountAllUserMedalsQuery : IRequest<int>
    {
        public int UserId { get; set; }
    }
}
