﻿// <auto-generated />
using Kurs_v3.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kurs_v3.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240528115933_Test")]
    partial class Test
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Kurs_v3.DB.Model.Assembly", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DialId")
                        .HasColumnType("int");

                    b.Property<int>("DisplayId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DialId");

                    b.HasIndex("DisplayId");

                    b.HasIndex("PlateId");

                    b.ToTable("Assemblies");
                });

            modelBuilder.Entity("Kurs_v3.DB.Model.Dial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Dials");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cost = 0,
                            Description = "",
                            Name = "None",
                            SerialNumber = "-"
                        });
                });

            modelBuilder.Entity("Kurs_v3.DB.Model.Display", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Displays");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cost = 0,
                            Description = "",
                            Name = "None",
                            SerialNumber = "-"
                        });
                });

            modelBuilder.Entity("Kurs_v3.DB.Model.Plate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Plates");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cost = 0,
                            Description = "",
                            Name = "None",
                            SerialNumber = "-"
                        });
                });

            modelBuilder.Entity("Kurs_v3.DB.Model.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NameOfPosition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Positions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NameOfPosition = "Админ"
                        },
                        new
                        {
                            Id = 2,
                            NameOfPosition = "Секретарь"
                        },
                        new
                        {
                            Id = 3,
                            NameOfPosition = "Конструктор"
                        },
                        new
                        {
                            Id = 4,
                            NameOfPosition = "Сборщик"
                        });
                });

            modelBuilder.Entity("Kurs_v3.DB.Model.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Position");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Login = "Admin",
                            Name = "Admin",
                            Password = "Admin",
                            Patronymic = "",
                            Position = 1,
                            Surname = "Admin"
                        });
                });

            modelBuilder.Entity("Kurs_v3.DB.Model.Assembly", b =>
                {
                    b.HasOne("Kurs_v3.DB.Model.Dial", "Dial")
                        .WithMany()
                        .HasForeignKey("DialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kurs_v3.DB.Model.Display", "Display")
                        .WithMany()
                        .HasForeignKey("DisplayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kurs_v3.DB.Model.Plate", "Plate")
                        .WithMany()
                        .HasForeignKey("PlateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dial");

                    b.Navigation("Display");

                    b.Navigation("Plate");
                });

            modelBuilder.Entity("Kurs_v3.DB.Model.Users", b =>
                {
                    b.HasOne("Kurs_v3.DB.Model.Position", "position")
                        .WithMany()
                        .HasForeignKey("Position")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("position");
                });
#pragma warning restore 612, 618
        }
    }
}
