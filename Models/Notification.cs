using StudentShadow.Enums;

namespace StudentShadow.Models
{
    public class Notification
    {
        public int Id { get; set; }

        public Token Token { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateOnly Date { get; set; }

        public TimeOnly Time { get; set; }

        public NotificationType Type { get; set; }
    }
}
