using StudentShadow.Enums;

namespace StudentShadow.Models
{
    public class Notification
    {
        public int Id { get; set; }

        public virtual Token Token { get; set; }


        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime? DateTime { get; set; }


        public NotificationType Type { get; set; }
    }
}
