using System.Data.Entity.Spatial;

namespace StudentShadow.Models
{
    public class School
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DbGeography Address { get; set; }

        public string Logo { get; set; }

        public string WebsiteURL { get; set; }
    }
}
