﻿using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Activities.Queries
{
    public class CountUserActivitiesQuery : IRequest<int>
    {
        public int Id { get; set; }
    }
}
