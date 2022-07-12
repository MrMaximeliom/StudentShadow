using StudentShadow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace StudentShadow.ModelsConfigurations
{
    public class DiseaseEntityTypeConfiguration:IEntityTypeConfiguration<Disease>
    {
        public void Configure(EntityTypeBuilder<Disease> builder)
        {
            // Configuring Name  property
            builder.Property(diseaseProperty => diseaseProperty.Name)
                .IsRequired(true)
                .HasMaxLength(300)
                .HasComment("Disease name");

            //Configuring Syptoms property
            builder.Property(diseaseProperty => diseaseProperty.Syptoms)
                .IsRequired(false)
                .HasComment("Syptoms");

            //Configuring GeneralGuides property
            builder.Property(diseaseProperty => diseaseProperty.GeneralDuides)
                .IsRequired(false)
                .HasComment("Disease general guides");




        }
    }
}
