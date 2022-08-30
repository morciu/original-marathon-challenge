namespace WebAPI.Dto
{
    public class ActivityPutPostDto
    {
        public int UserId { get; set; }
        public decimal Distance { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
