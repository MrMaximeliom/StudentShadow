using StudentShadow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace StudentShadow.ModelsConfigurations
{
    public class WalletEntityTypeConfiguration:IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            // Configure relationship
           
            // Configuring User property
            //builder.Property(walletProperty => walletProperty.User)
            //    .IsRequired(true)
            //    .HasComment("Student Id");

            //Configuring QRCode property
            builder.Property(walletProperty => walletProperty.QRCode)
                .IsRequired(true)
                .HasMaxLength(300)
                .HasComment("QRCode");

            //Configuring Amount property
            builder.Property(walletProperty => walletProperty.Amount)
                .IsRequired(true)
                .HasPrecision(9,3)
                .HasComment("Wallet amount");

            //Configuring LastUpdated property
            builder.Property(walletProperty => walletProperty.LastUpdatedDateTime)
                .IsRequired(false)
                .HasComment("LastUpdated");



        }
    }
}
