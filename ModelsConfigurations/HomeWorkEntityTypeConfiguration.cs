using StudentShadow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace StudentShadow.ModelsConfigurations
{
    public class HomeWorkEntityTypeConfiguration:IEntityTypeConfiguration<HomeWork>
    {
        public void Configure(EntityTypeBuilder<HomeWork> builder)
        {
            // Configuring Student property
            builder.Property(homeWorkProperty => homeWorkProperty.Student)
                .IsRequired(true)
                .HasComment("Student Id");

            //Configuring Subject property
            builder.Property(homeWorkProperty => homeWorkProperty.Subject)
                .IsRequired(true)
                .HasComment("Subject");

            //Configuring Teacher property
            builder.Property(homeWorkProperty => homeWorkProperty.Teacher)
                .IsRequired(true)
                .HasComment("Teacher Id");

            //Configuring AssignmentDate property
            builder.Property(homeWorkProperty => homeWorkProperty.AssignmentDate)
                .IsRequired(false)
                .HasComment("Assignment date");

            //Configuring DueDate property
            builder.Property(homeWorkProperty => homeWorkProperty.DueDate)
                .IsRequired(true)
                .HasComment("Due date");

            //Configuring DueStatus property
            builder.Property(homeWorkProperty => homeWorkProperty.DueStatus)
                .IsRequired(true)
                .HasMaxLength(100)
                .HasComment("Due status");





        }
    }
}
