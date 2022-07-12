using StudentShadow.Enums;
namespace StudentShadow.Models
{
   
    public class User
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public UserType UserType { get; set; }

        public string  Username { get; set; }

        public string Password { get; set; }

        public Gender Gender { get; set; }

        public string  Email { get; set; }


        public string PrimaryPhone { get; set; }

        public string? SecondaryPhone { get; set; }

        public string Image { get; set; }

        public string QRCode { get; set; }

    }
}
