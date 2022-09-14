using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Activity
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        public decimal Distance { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }
        public TimeSpan Pace { get; set; }

        public TimeSpan CalculatePace(decimal distance, TimeSpan duration)
        {
            var totalSeconds = duration.TotalSeconds;
            var paceInSeconds = Math.Round(totalSeconds / Convert.ToDouble(distance));
            var paceInMinutes = TimeSpan.FromSeconds(paceInSeconds);

            return paceInMinutes;
        }
    }
}
