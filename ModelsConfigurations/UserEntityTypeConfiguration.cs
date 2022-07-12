using StudentShadow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace StudentShadow.ModelsConfigurations
{
    public class UserEntityTypeConfiguration:IEntityTypeConfiguration<User>
          
    {
        public void Configure(EntityTypeBuilder<User> builder )
        {
            // Configuring FullName property
            builder.Property(userProperty => userProperty.FullName)
                .IsRequired(true)
                .HasMaxLength(400)
                .HasComment("User full name");

            //Configuring UserType property
            builder.Property(userProperty => userProperty.UserType)
                .IsRequired(true)
                .HasMaxLength(8)
                .HasComment("User type");

            //Configuring Username property
            builder.Property(userProperty => userProperty.Username)
                .IsRequired(false)
                .HasMaxLength(100)
                .HasComment("Username");

            //Configuring Password property
            builder.Property(userProperty => userProperty.Password)
                .IsRequired(true)
                .HasMaxLength(80)
                .HasComment("User password");

            //Configuring Gender property
            builder.Property(userProperty => userProperty.Gender)
                .IsRequired(false)
                .HasMaxLength(10)
                .HasComment("User gender");

            //Configuring Email property
            builder.Property(userProperty => userProperty.Email)
                .IsRequired(true)
                .HasMaxLength(50)
                .HasComment("User email");

            //Configuring PrimaryPhone property
            builder.Property(userProperty => userProperty.PrimaryPhone)
                .IsRequired(true)
                .HasMaxLength(20)
                .HasComment("User primary phone");

            //Configuring SecondaryPhone property
            builder.Property(userProperty => userProperty.SecondaryPhone)
                .IsRequired(false)
                .HasMaxLength(20)
                .HasComment("User secondary phone");

            //Configuring Image property
            builder.Property(userProperty => userProperty.Image)
                .IsRequired(false)
                .HasMaxLength(400)
                .HasComment("User image");

            //Configuring QRCode property
            builder.Property(userProperty => userProperty.QRCode)
                .IsRequired(true)
                .HasMaxLength(300)
                .HasComment("User QR Code");



        }

    }
}
