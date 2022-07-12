namespace StudentShadow.Models
{
    public class HomeWork
    {
        public int Id { get; set; }

        public User Student { get; set; }

        public Subject Subject { get; set; }

        public User Teacher { get; set; }

        public DateOnly AssignmentDate { get; set; }

        public DateOnly DueDate { get; set; }

        public string DueStatus { get; set; }
    }
}
