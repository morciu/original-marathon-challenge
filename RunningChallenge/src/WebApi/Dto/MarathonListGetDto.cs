namespace WebApi.Dto
{
    public class MarathonListGetDto
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public int MemberCount { get; set; }
        public bool IsDone { get; set; }
        public List<int> MemberIdList { get; set; }
    }
}
