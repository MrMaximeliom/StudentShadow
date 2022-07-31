namespace StudentShadow.Models
{
    public class Degree
    {
        public int Id { get; set; }

        public virtual User User { get; set; }

        public virtual Subject Subject { get; set; }

        public string  CharGrade { get; set; }

        public DateTime? DateTime { get; set; }
    }
}
