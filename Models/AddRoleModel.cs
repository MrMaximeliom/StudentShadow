using System.ComponentModel.DataAnnotations;

namespace StudentShadow.Models
{
    public class AddRoleModel
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string  Role { get; set; }  
    }
}
