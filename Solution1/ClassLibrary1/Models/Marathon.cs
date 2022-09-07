using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Marathon
    {
/*        public const float DistanceGoal = 240;*/
        public ICollection<User> Members { get; set; }
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
/*
        public virtual string ShowProgress()
        {
            return $"Everyone's marathon progress";
        }

        public string ShowProgress(User user)
        {
            return $"{user.UserName}'s marathon progress";
        }

        public virtual string ShowFinishers()
        {
            return "No finishers";
        }*/
    }
}
