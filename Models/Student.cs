namespace StudentShadow.Models
{
    public class Student
    {
        public int Id { get; set; }

        public virtual School School { get; set; }

        public virtual Grade Grade { get; set; }

        public virtual User User { get; set; }

    }
}
