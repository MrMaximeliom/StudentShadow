using StudentShadow.Enums;
using System.ComponentModel.DataAnnotations;

namespace StudentShadow.Helpers
{
    public class CustomUser
    {
        public int Id { get; set; }

        [Required,StringLength(300)]
        public string FullName { get; set; }

        [Required, StringLength(100)]
        public string Email { get; set; }

        public Gender Gender { get; set; }

        public string? SecondaryPhone { get; set; }

        public string? Image { get; set; }

        public string? QRCode { get; set; }

        [Required, StringLength(40)]
        public string UserName { get; set; }

        [Required, StringLength(10)]
        public string Password { get; set; }

        [Required, StringLength(20)]
        public string PhoneNumber { get; set; }

    }
}
