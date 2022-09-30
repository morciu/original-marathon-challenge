using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class User : IdentityUser<int>
    {
        [MaxLength(20)]
        public string FirstName { get; set; } = null!;

        [MaxLength(20)] 
        public string LastName { get; set; } = null!;

        public decimal TotalDistance { get; set; }
        public TimeSpan TotalTime { get; set; }
        public TimeSpan AveragePace { get; set; }

        public ICollection<Activity> Activities { get; set; } = null!;
        public ICollection<Marathon> Marathons { get; set; } = null!;

        public decimal CalculateTotalDistance()
        {
            decimal totalDistance = 0;
            foreach (var activity in Activities)
            {
                totalDistance += activity.Distance;
            }
            return totalDistance;
        }

        public TimeSpan CalculateTotalTime()
        {
            TimeSpan result = TimeSpan.Zero;
            foreach (var activity in Activities)
            {
                result += activity.Duration;
            }
            return result;
        }

        public TimeSpan CalculateAveragePace()
        {
            if(Activities.Count == 0)
            {
                return TimeSpan.Zero;
            }
            var totalSeconds = CalculateTotalTime().TotalSeconds;
            var paceInSeconds = Math.Round(totalSeconds / Convert.ToDouble(CalculateTotalDistance()));
            var paceInMinutes = TimeSpan.FromSeconds(paceInSeconds);

            return paceInMinutes;
        }
    }
}
