using StudentShadow.Enums;

namespace StudentShadow.Models
{
    public class Token
    {
        public int Id { get; set; }

        public string RegisterationToken { get; set; }

        public virtual User User { get; set; }

        public OSType? OSType { get; set; }
    }
}
