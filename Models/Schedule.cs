namespace StudentShadow.Models
{
    public class Schedule
    {
        public int Id { get; set; }

        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public DateTime? DateTime { get; set; }
    }
}
