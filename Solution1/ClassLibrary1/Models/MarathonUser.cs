using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class MarathonUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int MarathonId { get; set; }
        public Marathon Marathon { get; set; }
    }
}
