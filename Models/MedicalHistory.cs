namespace StudentShadow.Models
{
    public class MedicalHistory
    {
        public int Id { get; set; }

        public User User { get; set; }

        public Disease Disease { get; set; }

        public DateTime ExaminedDateTime { get; set; }

        public string Note { get; set; }
    }
}
