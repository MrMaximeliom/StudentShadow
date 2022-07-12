using StudentShadow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace StudentShadow.ModelsConfigurations
{
    public class SubjectEntityTypeConfiguration:IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            // Configuring Title property
            builder.Property(subjectProperty => subjectProperty.Title)
                .IsRequired(true)
                .HasMaxLength(300)
                .HasComment("Subject title");

            //Configuring Grade property
            builder.Property(subjectProperty => subjectProperty.Grade)
                .IsRequired(true)
                .HasComment("Grade");

            //Configuring StartDate property
            builder.Property(subjectProperty => subjectProperty.StartDate)
                .IsRequired(false)
                .HasComment("Subject start date");

            //Configuring EndDate property
            builder.Property(subjectProperty => subjectProperty.EndDate)
                .IsRequired(false)
                .HasComment("Subject End Date");



        }
    }
}
