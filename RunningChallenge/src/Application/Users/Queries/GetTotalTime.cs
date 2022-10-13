using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries
{
    public class GetTotalTime : IRequest<TimeSpan>
    {
        public int Id { get; set; }
    }
}
