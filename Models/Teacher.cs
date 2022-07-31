namespace StudentShadow.Models
{
    public class Teacher
    {

        public int Id { get; set; }

        public virtual School School { get; set; }


        public virtual User User { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Subject> Subjects { get; private set; }

        public Teacher()
        {
            this.Subjects = new HashSet<Subject>();
        }


    }
}
