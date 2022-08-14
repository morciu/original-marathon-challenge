using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Activity
    {
        public int _runnerId;
        public decimal _distance;
        public DateTime _date;
        public TimeSpan _duration;

        public Activity(int runnerId, decimal distance, DateTime date, TimeSpan duration)
        {
            _runnerId = runnerId;
            _distance = distance;
            _date = date;
            _duration = duration;
        }
    }
}
