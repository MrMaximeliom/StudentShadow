using StudentShadow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace StudentShadow.ModelsConfigurations
{
    public class HomeWorkEntityTypeConfiguration:IEntityTypeConfiguration<HomeWork>
    {
        public void Configure(EntityTypeBuilder<HomeWork> builder)
        {
            //Configuring Student property
            builder.HasOne(x => x.Student)
              .WithMany()
              .OnDelete(DeleteBehavior.NoAction);

            //Configuring Subject property
            builder.HasOne(x => x.Subject)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            //Configuring Teacher property
            builder.HasOne(x => x.Teacher)
              .WithMany()
              .OnDelete(DeleteBehavior.NoAction);



            //Configuring AssignmentDate property
            builder.Property(homeWorkProperty => homeWorkProperty.AssignmentDateTime)
                .IsRequired(false)
                .HasComment("Assignment date");

            //Configuring DueDate property
            builder.Property(homeWorkProperty => homeWorkProperty.DueDateTime)
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
