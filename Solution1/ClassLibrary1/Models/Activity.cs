using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public decimal Distance { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }

/*        public Activity(int userId, decimal distance, DateTime date, TimeSpan duration)
        {
            UserId = userId;
            Distance = distance;
            Date = date;
            Duration = duration;
        }*/
    }
}
