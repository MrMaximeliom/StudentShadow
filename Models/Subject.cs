namespace StudentShadow.Models
{
    public class Subject
    {
       
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual Grade Grade { get; set; }


        public DateTime? StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        public decimal FullDegree { get; set; }

        public decimal PassDegree { get; set; }
        public virtual ICollection<Teacher> Teachers { get; private set; }
        public Subject()
        {
            this.Teachers = new HashSet<Teacher>();
        }

    }
}
