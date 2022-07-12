using StudentShadow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace StudentShadow.ModelsConfigurations
{
    public class TokenEntityTypeConfiguration:IEntityTypeConfiguration<Token>
    {
        public void Configure(EntityTypeBuilder<Token> builder)
        {
            // Configuring RegisterationToken property
            builder.Property(registerationToken => registerationToken.RegisterationToken)
                .IsRequired(true)
                .HasMaxLength(200)
                .HasComment("Registeration Token");

            //Configuring User property
            builder.Property(registerationToken => registerationToken.User)
                .IsRequired(true)
                .HasComment("User Id");

            //Configuring OsType property
            builder.Property(registerationToken => registerationToken.OSType)
                .IsRequired(false)
                .HasMaxLength(10)
                .HasComment("OS Type");


        }
    }
}
