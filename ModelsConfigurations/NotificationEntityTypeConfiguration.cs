using StudentShadow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace StudentShadow.ModelsConfigurations
{
    public class NotificationEntityTypeConfiguration:IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            // Configuring Token property
            //builder.Property(notificationProperty => notificationProperty.Token)
            //    .IsRequired(true)
            //    .HasComment("Token Id");

            //Configuring Title property
            builder.Property(notificationProperty => notificationProperty.Title)
                .IsRequired(true)
                .HasMaxLength(200)
                .HasComment("Notification title");

            //Configuring Content property
            builder.Property(notificationProperty => notificationProperty.Content)
                .IsRequired(true)
                .HasMaxLength(300)
                .HasComment("Notification content");


            //Configuring Date property
            builder.Property(notificationProperty => notificationProperty.DateTime)
                .IsRequired(false)
                .HasComment("Notification date");

          

            //Configuring Type property
            builder.Property(notificationProperty => notificationProperty.Type)
                .IsRequired(true)
                .HasMaxLength(50)
                .HasComment("Notification type");



        }
    }
}
