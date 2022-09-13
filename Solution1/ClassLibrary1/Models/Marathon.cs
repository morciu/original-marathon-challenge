using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Marathon
    {
        public ICollection<User> Members { get; set; }
        public int Id { get; set; }
        public DateTime StartDate { get; set; }

        public decimal CalculateTotalDistaceForMember(User user)
        {
            decimal result = 0;
            foreach(var activity in user.Activities)
            {
                result += activity.Distance;
            }
            return result;
        }
    }
}
