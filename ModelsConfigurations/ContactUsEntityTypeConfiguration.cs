using StudentShadow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace StudentShadow.ModelsConfigurations
{
    public class ContactUsEntityTypeConfiguration:IEntityTypeConfiguration<ContactUs>
    {
        public void Configure(EntityTypeBuilder<ContactUs> builder)
        {
            // Configuring DeveloperName property
            builder.Property(contactUsProperty => contactUsProperty.DeveloperName)
                .IsRequired(true)
                .HasMaxLength(300)
                .HasComment("Developer name");

            //Configuring WebsiteURL property
            builder.Property(contactUsProperty => contactUsProperty.Email)
                .IsRequired(true)
                .HasMaxLength(100)
                .HasComment("Email");

            //Configuring PhoneNumber property
            builder.Property(contactUsProperty => contactUsProperty.PhoneNumber)
                .IsRequired(true)
                .HasMaxLength(20)
                .HasComment("Phone number");

            //Configuring JobTitle property
            builder.Property(contactUsProperty => contactUsProperty.JobTitle)
                .IsRequired(true)
                .HasMaxLength(300)
                .HasComment("Job title");

            //Configuring Image property
            builder.Property(contactUsProperty => contactUsProperty.Image)
                .IsRequired(false)
                .HasMaxLength(300)
                .HasComment("image");



        }
    }
}
