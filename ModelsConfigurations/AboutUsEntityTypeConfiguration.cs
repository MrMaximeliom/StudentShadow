using StudentShadow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace StudentShadow.ModelsConfigurations
{
    public class AboutUsEntityTypeConfiguration:IEntityTypeConfiguration<AboutUs>
    {
        public void Configure(EntityTypeBuilder<AboutUs> builder)
        {
            // Configuring CompanyName property
            builder.Property(aboutUsProperty => aboutUsProperty.CompanyName)
                .IsRequired(true)
                .HasMaxLength(100)
                .HasComment("Company name");

            //Configuring WebsiteURL property
            builder.Property(aboutUsProperty => aboutUsProperty.WebsiteURL)
                .IsRequired(true)
                .HasMaxLength(200)
                .HasComment("Website URL");

            //Configuring Description property
            builder.Property(aboutUsProperty => aboutUsProperty.Description)
                .IsRequired(false)
                .HasMaxLength(300)
                .HasComment("Description");

            //Configuring Email property
            builder.Property(aboutUsProperty => aboutUsProperty.Email)
                .IsRequired(true)
                .HasMaxLength(100)
                .HasComment("Email");

            //Configuring Logo property
            builder.Property(aboutUsProperty => aboutUsProperty.Logo)
                .IsRequired(true)
                .HasMaxLength(300)
                .HasComment("Logo");



        }
    }
}
