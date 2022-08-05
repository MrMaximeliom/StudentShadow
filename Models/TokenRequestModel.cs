using System.ComponentModel.DataAnnotations;

namespace StudentShadow.Models
{
    public class TokenRequestModel
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
