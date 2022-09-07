namespace WebAPI.Dto
{
    public class UserGetDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public List<ActivityGetDto> Activities { get; set; }
    }
}
