using WebApi.Dto;

namespace WebAPI.Dto
{
    public class UserGetDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public decimal TotalDistance { get; set; }
        public TimeSpan TotalTime { get; set; }
        public TimeSpan AveragePace { get; set; }
        public List<ActivityGetDto> Activities { get; set; }
        public List<MarathonListGetDto> Marathons { get; set; }
        public List<MedalGetDto> Medals { get; set; }
    }
}
