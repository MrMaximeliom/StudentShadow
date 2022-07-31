using Microsoft.AspNetCore.Identity;
using StudentShadow.Enums;
namespace StudentShadow.Models
{
   
    public class User : IdentityUser
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public UserType UserType { get; set; }

        public Gender Gender { get; set; }

        public string? SecondaryPhone { get; set; }

        public string Image { get; set; }

        public string QRCode { get; set; }

    }
}
