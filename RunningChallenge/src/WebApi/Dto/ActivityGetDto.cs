using Domain.Models;

namespace WebAPI.Dto
{
    public class ActivityGetDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Distance { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }
        public TimeSpan Pace { get; set; }
        public int LikeCount { get; set; }
    }
}
