using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Medal
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int MarathonId { get; set; }
        public Marathon Marathon { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public TimeSpan Pace { get; set; }
    }
}
