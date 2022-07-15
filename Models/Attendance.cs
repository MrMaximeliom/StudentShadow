namespace StudentShadow.Models
{
    public class Attendance
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public DateTime? DateTime { get; set; }

        public bool IsAttended { get; set; }
    }
}
