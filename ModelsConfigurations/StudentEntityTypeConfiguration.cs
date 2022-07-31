using StudentShadow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace StudentShadow.ModelsConfigurations
{
    public class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>

    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            // Configuring School property
            //builder.Property(studentProperty => studentProperty.School)
            //    .IsRequired(true)
            //    .HasComment("Student school");

            //Configuring Grade property
            //builder.Property(studentProperty => studentProperty.Grade)
            //    .IsRequired(true)
            //    .HasComment("Student grade");

            //Configuring User property
            //builder.Property(studentProperty => studentProperty.User)
            //    .IsRequired(false)
            //    .HasComment("User Id");

            //builder.HasIndex(
            //   b => new { b.Id, b.User }
            //    )
            //    .IsUnique();

        }

    }
}
