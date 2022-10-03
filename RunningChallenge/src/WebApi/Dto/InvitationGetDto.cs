using WebAPI.Dto;

namespace WebApi.Dto
{
    public class InvitationGetDto
    {
        public int Id { get; set; }
        public UserGetDto Sender { get; set; }
        public UserGetDto Receiver { get; set; }
        public MarathonGetDto Marathon { get; set; }
    }
}
