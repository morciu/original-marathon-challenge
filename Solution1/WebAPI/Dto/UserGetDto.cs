namespace WebAPI.Dto
{
    public class UserGetDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public decimal TotalDistance { get; set; }
        public List<ActivityGetDto> Activities { get; set; }
    }
}
