namespace WebAPI.Dto
{
    public class MarathonGetDto
    {
        public List<UserGetDto>? Members { get; set; }
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
    }
}
