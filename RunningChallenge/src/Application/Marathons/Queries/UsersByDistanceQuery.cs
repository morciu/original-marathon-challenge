﻿using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Marathons.Queries
{
    public class UsersByDistanceQuery : IRequest<List<User>>
    {
        public int Id { get; set; }
        public int PageNr { get; set; }
        public int PageSize { get; set; }
    }
}
