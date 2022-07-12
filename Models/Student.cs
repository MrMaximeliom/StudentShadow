namespace StudentShadow.Models
{
    public class Student
    {
        public int Id { get; set; }

        public School School { get; set; }

        public Grade Grade { get; set; }

        public User User { get; set; }

    }
}
