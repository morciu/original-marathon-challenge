using MediatR;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Activities.Commands.CreateActivity
{
    internal class CreateActivityCommand : IRequest<Activity>
    {
        public int RunnerId { get; set; }
        public float Distance { get; set; }
        public DateTime Date { get; set; }
        public DateTime Duration { get; set; }
    }
}
