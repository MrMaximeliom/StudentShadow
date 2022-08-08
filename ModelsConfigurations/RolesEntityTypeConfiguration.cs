using StudentShadow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;

namespace StudentShadow.ModelsConfigurations
{
    public class RolesEntityTypeConfiguration : IEntityTypeConfiguration<IdentityRole>

    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            // Configuring Id property
            builder.Property(roleProperty => roleProperty.Id)
                .IsRequired(true)
                .ValueGeneratedOnAdd();
        }
    }
}