using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Activities.Commands.CreateActivity
{
    public class CreateActivityCommand : IRequest<Activity>
    {
        public int RunnerId { get; set; }
        public decimal Distance { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
