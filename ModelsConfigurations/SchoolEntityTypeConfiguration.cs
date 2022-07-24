using StudentShadow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace StudentShadow.ModelsConfigurations
{
    public class SchoolEntityTypeConfiguration:IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            // Configuring Name property
            builder.Property(schoolProperty => schoolProperty.Name)
                .IsRequired(true)
                .HasMaxLength(300)
                .HasComment("School name");


            //Configuring Logo property
            builder.Property(schoolProperty => schoolProperty.Logo)
                .IsRequired(false)
                .HasMaxLength(400)
                .HasComment("School logo");

            //Configuring WebsiteURL property
            builder.Property(schoolProperty => schoolProperty.WebsiteURL)
                .IsRequired(false)
                .HasMaxLength(100)
                .HasComment("WebsiteURL");




        }
    }
}
