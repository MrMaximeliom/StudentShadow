namespace StudentShadow.Models
{
    public class Subject
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Grade Grade { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public decimal FullDegree { get; set; }

        public decimal PassDegree { get; set; }
    }
}
