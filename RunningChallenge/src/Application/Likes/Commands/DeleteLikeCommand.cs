using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Likes.Commands
{
    public class DeleteLikeCommand : IRequest<Like>
    {
        public int ActivityId { get; set; }
        public int SenderId { get; set; }
    }
}
