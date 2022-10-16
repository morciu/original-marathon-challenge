using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Likes.Commands
{
    public class CreateLikeCommand : IRequest<Like>
    {
        public int SenderId { get; set; }
        public int ActivityId { get; set; }
    }
}
