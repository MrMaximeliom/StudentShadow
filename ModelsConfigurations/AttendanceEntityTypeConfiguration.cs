using StudentShadow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace StudentShadow.ModelsConfigurations
{
    public class AttendanceEntityTypeConfiguration:IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            // Configuring User property
            //builder.Property(attendanceProperty => attendanceProperty.User)
            //    .IsRequired(true)
            //    .HasComment("Student Id");

            //Configuring Subject  property
            //builder.Property(attendanceProperty => attendanceProperty.Subject)
            //    .IsRequired(true)
            //    .HasComment("Subject Id");

            //Configuring Date property
            builder.Property(attendanceProperty => attendanceProperty.DateTime)
                .IsRequired(false)
                .HasComment("Date");

            //Configuring IsAttended property
            builder.Property(attendanceProperty => attendanceProperty.IsAttended)
                .IsRequired(true)
                .HasMaxLength(3)
                .HasComment("Is student attended?");

        }
    }
}
