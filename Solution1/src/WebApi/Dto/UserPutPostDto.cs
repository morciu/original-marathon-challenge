using System.ComponentModel.DataAnnotations;

namespace WebAPI.Dto
{
    public class UserPutPostDto
    {
        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(4)]
        public string Password { get; set; }
    }
}
