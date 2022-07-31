namespace StudentShadow.Models
{
    public class Wallet
    {
        public int Id { get; set; }


        public virtual User User { get; set; }

        public String  QRCode { get; set; }

        public decimal Amount { get; set; }

        public DateTime? LastUpdatedDateTime { get; set; }
    }
}
