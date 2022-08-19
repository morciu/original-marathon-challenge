using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Activities.Queries.GetActivity
{
    public class GetAllUserActivitiesQuery : IRequest<List<Activity>>
    {
        public int UserId { get; set;}
    }
}
