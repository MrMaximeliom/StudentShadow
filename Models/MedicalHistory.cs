namespace StudentShadow.Models
{
    public class MedicalHistory
    {
        public int Id { get; set; }

        public virtual User User { get; set; }

        public virtual Disease Disease { get; set; }

        public DateTime? ExaminedDateTime { get; set; }

        public string Note { get; set; }
    }
}
