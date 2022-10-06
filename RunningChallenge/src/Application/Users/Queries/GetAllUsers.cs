﻿using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries
{
    public class GetAllUsers : IRequest<List<User>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
