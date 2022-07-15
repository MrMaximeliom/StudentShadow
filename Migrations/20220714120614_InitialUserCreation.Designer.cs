﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentShadow.Data;

#nullable disable

namespace StudentShadow.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20220714120614_InitialUserCreation")]
    partial class InitialUserCreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("StudentShadow.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("User email");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)")
                        .HasComment("User full name");

                    b.Property<int>("Gender")
                        .HasMaxLength(10)
                        .HasColumnType("int")
                        .HasComment("User gender");

                    b.Property<string>("Image")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)")
                        .HasComment("User image");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasComment("User password");

                    b.Property<string>("PrimaryPhone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("User primary phone");

                    b.Property<string>("QRCode")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasComment("User QR Code");

                    b.Property<string>("SecondaryPhone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("User secondary phone");

                    b.Property<int>("UserType")
                        .HasMaxLength(8)
                        .HasColumnType("int")
                        .HasComment("User type");

                    b.Property<string>("Username")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}