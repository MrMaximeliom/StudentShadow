namespace StudentShadow.Models
{
    public class Schedule
    {
        public int Id { get; set; }

        public Subject Subject { get; set; }

        public DateOnly Date { get; set; }
    }
}
