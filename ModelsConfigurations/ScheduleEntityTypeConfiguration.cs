using StudentShadow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace StudentShadow.ModelsConfigurations
{
    public class ScheduleEntityTypeConfiguration:IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            // Configuring Subject property
            //builder.Property(scheduleProperty => scheduleProperty.Subject)
            //    .IsRequired(true)
            //    .HasComment("Subject");

            //Configuring Date property
            builder.Property(scheduleProperty => scheduleProperty.DateTime)
                .IsRequired(false)
                .HasComment("Date");





        }
    }
}
