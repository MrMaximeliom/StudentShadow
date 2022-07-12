namespace StudentShadow.Models
{
    public class Attendance
    {
        public int Id { get; set; }

        public User User { get; set; }

        public Subject Subject { get; set; }

        public DateOnly Date { get; set; }

        public bool IsAttended { get; set; }
    }
}
