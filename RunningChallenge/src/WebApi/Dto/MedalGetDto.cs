namespace WebApi.Dto
{
    public class MedalGetDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MarathonId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public TimeSpan Pace { get; set; }
    }
}
