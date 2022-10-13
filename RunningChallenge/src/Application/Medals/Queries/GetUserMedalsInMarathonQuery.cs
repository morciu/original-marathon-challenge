using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Medals.Queries
{
    public class GetUserMedalsInMarathonQuery : IRequest<List<Medal>>
    {
        public int UserId { get; set; }
        public int MarathonId { get; set; }
    }
}
