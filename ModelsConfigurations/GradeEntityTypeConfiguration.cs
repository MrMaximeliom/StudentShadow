using StudentShadow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace StudentShadow.ModelsConfigurations
{
    public class GradeEntityTypeConfiguration:IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            // Configuring GradeName property
            builder.Property(gradeProperty => gradeProperty.Name)
                .IsRequired(true)
                .HasMaxLength(150)
                .HasComment("Grade name");

            

        }
    }
}
