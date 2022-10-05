namespace WebApi.Dto
{
    public class InvitationPutPostDto
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public int MarathonId { get; set; }
    }
}
