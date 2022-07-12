namespace StudentShadow.Models
{
    public class Degree
    {
        public int Id { get; set; }

        public User User { get; set; }

        public Subject Subject { get; set; }

        public string  CharGrade { get; set; }

        public DateOnly Date { get; set; }
    }
}
