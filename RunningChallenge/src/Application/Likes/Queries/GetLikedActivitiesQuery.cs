using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Likes.Queries
{
    public class GetLikedActivitiesQuery : IRequest<List<int>>
    {
        public int UserId { get; set; }
    }
}
