﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpacePark.source.Context;

namespace SpacePark.API.Migrations
{
    [DbContext(typeof(SpaceParkContext))]
    partial class SpaceParkContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SpacePark.API.Models.Parkinglot", b =>
                {
                    b.Property<int>("ParkingLotID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ParkingLotOccupied")
                        .HasColumnType("bit");

                    b.Property<int>("SpacePortID")
                        .HasColumnType("int");

                    b.HasKey("ParkingLotID");

                    b.HasIndex("SpacePortID")
                        .IsUnique();

                    b.ToTable("ParkingLots");
                });

            modelBuilder.Entity("SpacePark.API.Models.Spaceport", b =>
                {
                    b.Property<int>("SpacePortID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("SpacePortID");

                    b.ToTable("SpacePorts");
                });

            modelBuilder.Entity("SpacePark.API.Models.Visitor", b =>
                {
                    b.Property<int>("VisitorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Payed")
                        .HasColumnType("int");

                    b.HasKey("VisitorID");

                    b.ToTable("Visitors");
                });

            modelBuilder.Entity("SpacePark.API.Models.VisitorParking", b =>
                {
                    b.Property<int>("VistorParkingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfEntry")
                        .HasColumnType("datetime2");

                    b.Property<int>("ParkingLotID")
                        .HasColumnType("int");

                    b.Property<int>("VisitorID")
                        .HasColumnType("int");

                    b.HasKey("VistorParkingID");

                    b.HasIndex("ParkingLotID");

                    b.HasIndex("VisitorID");

                    b.ToTable("VisitorParkings");
                });

            modelBuilder.Entity("SpacePark.API.Models.Parkinglot", b =>
                {
                    b.HasOne("SpacePark.API.Models.Spaceport", null)
                        .WithOne("Parkinglot")
                        .HasForeignKey("SpacePark.API.Models.Parkinglot", "SpacePortID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SpacePark.API.Models.VisitorParking", b =>
                {
                    b.HasOne("SpacePark.API.Models.Parkinglot", "Parkinglot")
                        .WithMany()
                        .HasForeignKey("ParkingLotID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpacePark.API.Models.Visitor", "Vistor")
                        .WithMany()
                        .HasForeignKey("VisitorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
