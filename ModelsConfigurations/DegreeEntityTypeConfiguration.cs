using StudentShadow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace StudentShadow.ModelsConfigurations
{
    public class DegreeEntityTypeConfiguration:IEntityTypeConfiguration<Degree>
    {
        public void Configure(EntityTypeBuilder<Degree> builder)
        {
            // Configuring User property
            //builder.Property(DegreeProperty => DegreeProperty.User)
            //    .IsRequired(true)
            //    .HasComment("Student Id");

            //Configuring Subject property
            //builder.Property(DegreeProperty => DegreeProperty.Subject)
            //    .IsRequired(true)
            //    .HasComment("Subject");

            //Configuring CharGrade property
            builder.Property(DegreeProperty => DegreeProperty.CharGrade)
                .IsRequired(true)
                .HasMaxLength(10)
                .HasComment("Char grade");

            //Configuring Date property
            builder.Property(DegreeProperty => DegreeProperty.DateTime)
                .IsRequired(false)
                .HasComment("Date");



        }
    }
}
