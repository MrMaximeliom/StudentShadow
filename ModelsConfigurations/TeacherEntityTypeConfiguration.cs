using StudentShadow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace StudentShadow.ModelsConfigurations
{
    public class TeacherEntityTypeConfiguration:IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            // Configuring School property
            //builder.Property(teacherProperty => teacherProperty.School)
            //    .IsRequired(true)
            //    .HasComment("School Id");

            //Configuring User property
            //builder.Property(teacherProperty => teacherProperty.User)
            //    .IsRequired(true)
            //    .HasComment("Teacher Id");

            //builder.HasIndex(
            //   b => new { b.Id, b.User }
            //    ).IsUnique();
            

            //Configuring Description property
            builder.Property(teacherProperty => teacherProperty.Description)
                .IsRequired(false)
                .HasMaxLength(300)
                .HasComment("Description");

            //Configuring Subject property
            //builder.Property(teacherProperty => teacherProperty.Subject)
            //    .IsRequired(true)
            //    .HasComment("Subject");



        }
    }
}
