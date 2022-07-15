namespace StudentShadow.Models
{
    public class HomeWork
    {
        public int Id { get; set; }

        public int? StudentId { get; set; }
        public virtual Student Student { get; set; }

        public int? SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public int? TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        public DateTime? AssignmentDateTime { get; set; }

        public DateTime? DueDateTime { get; set; }

        public string DueStatus { get; set; }
    }
}
