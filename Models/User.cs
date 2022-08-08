using Microsoft.AspNetCore.Identity;
using StudentShadow.Enums;
using System.ComponentModel.DataAnnotations;

namespace StudentShadow.Models
{
   
    public class User : IdentityUser
    {
   
        public string FullName { get; set; }

        public Gender Gender { get; set; }

        public string? SecondaryPhone { get; set; }

        public string? Image { get; set; }

        public string? QRCode { get; set; }

     

    }
}
