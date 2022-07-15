using StudentShadow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace StudentShadow.ModelsConfigurations
{
    public class MedicalHistoryEntityTypeConfiguration:IEntityTypeConfiguration<MedicalHistory>
    {
        public void Configure(EntityTypeBuilder<MedicalHistory> builder)
        {
            // Configuring User property
            //builder.Property(medicalHistoryProperty => medicalHistoryProperty.User)
            //    .IsRequired(true)
            //    .HasComment("Student Id");

            //Configuring Disease property
            //builder.Property(medicalHistoryProperty => medicalHistoryProperty.Disease)
            //    .IsRequired(true)
            //    .HasComment("Student disease");

            //Configuring ExaminedDate property
            builder.Property(medicalHistoryProperty => medicalHistoryProperty.ExaminedDateTime)
                .IsRequired(false)
                .HasComment("Examined Date and Time");

            //Configuring Note property
            builder.Property(medicalHistoryProperty => medicalHistoryProperty.Note)
                .IsRequired(false)
                .HasComment("Notes");



        }
    }
}
