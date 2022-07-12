namespace StudentShadow.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        public School School { get; set; }

        public User User { get; set; }

        public string Description { get; set; }

        public Subject Subject { get; set; }


    }
}
