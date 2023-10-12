﻿// <auto-generated />
using FindYourHome.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FindYourHome.API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FindYourHome.Shared.Entities.Advisor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Advisors");
                });

            modelBuilder.Entity("FindYourHome.Shared.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StateId", "Name")
                        .IsUnique();

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("FindYourHome.Shared.Entities.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("FindYourHome.Shared.Entities.Ownership", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("AdvisorId")
                        .HasColumnType("int");

                    b.Property<decimal>("MonthlyPrice")
                        .HasPrecision(20, 2)
                        .HasColumnType("decimal(20,2)");

                    b.Property<int>("NumberOfBathrooms")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfRooms")
                        .HasColumnType("int");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("AdvisorId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("OwnerId");

                    b.ToTable("Ownerships");
                });

            modelBuilder.Entity("FindYourHome.Shared.Entities.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("States");
                });

            modelBuilder.Entity("FindYourHome.Shared.Entities.City", b =>
                {
                    b.HasOne("FindYourHome.Shared.Entities.State", "State")
                        .WithMany("Cities")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("FindYourHome.Shared.Entities.Ownership", b =>
                {
                    b.HasOne("FindYourHome.Shared.Entities.Advisor", "Advisor")
                        .WithMany("Ownerships")
                        .HasForeignKey("AdvisorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FindYourHome.Shared.Entities.Owner", "Owner")
                        .WithMany("Ownerships")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Advisor");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("FindYourHome.Shared.Entities.Advisor", b =>
                {
                    b.Navigation("Ownerships");
                });

            modelBuilder.Entity("FindYourHome.Shared.Entities.Owner", b =>
                {
                    b.Navigation("Ownerships");
                });

            modelBuilder.Entity("FindYourHome.Shared.Entities.State", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
