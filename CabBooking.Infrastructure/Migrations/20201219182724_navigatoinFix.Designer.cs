﻿// <auto-generated />
using System;
using CabBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CabBooking.Infrastructure.Migrations
{
    [DbContext(typeof(CabBookingDbContext))]
    [Migration("20201219182724_navigatoinFix")]
    partial class navigatoinFix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("CabBooking.Core.Entities.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime?>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BookingTime")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<int?>("CabTypeId")
                        .HasColumnType("int");

                    b.Property<string>("ContactNo")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("FromPlaceId")
                        .HasColumnType("int");

                    b.Property<string>("Landmark")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PickupAddress")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("PickupDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PickupTime")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Status")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("ToPlaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CabTypeId");

                    b.HasIndex("FromPlaceId");

                    b.HasIndex("ToPlaceId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("CabBooking.Core.Entities.BookingHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime?>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BookingTime")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<int?>("CabTypeId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Charge")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CompTime")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("ContactNo")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FeedBack")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("FromPlaceId")
                        .HasColumnType("int");

                    b.Property<string>("Landmark")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PickupAddress")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("PickupDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PickupTime")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Status")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("ToPlaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CabTypeId");

                    b.HasIndex("FromPlaceId");

                    b.HasIndex("ToPlaceId");

                    b.ToTable("BookingHistory");
                });

            modelBuilder.Entity("CabBooking.Core.Entities.CabType", b =>
                {
                    b.Property<int>("CabTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CabTypeName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("CabTypeId");

                    b.ToTable("CabType");
                });

            modelBuilder.Entity("CabBooking.Core.Entities.Place", b =>
                {
                    b.Property<int>("PlaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("PlaceName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("PlaceId");

                    b.ToTable("Place");
                });

            modelBuilder.Entity("CabBooking.Core.Entities.Booking", b =>
                {
                    b.HasOne("CabBooking.Core.Entities.CabType", "CabType")
                        .WithMany("Bookings")
                        .HasForeignKey("CabTypeId");

                    b.HasOne("CabBooking.Core.Entities.Place", "FromPlace")
                        .WithMany("FromBookings")
                        .HasForeignKey("FromPlaceId");

                    b.HasOne("CabBooking.Core.Entities.Place", "ToPlace")
                        .WithMany("ToBookings")
                        .HasForeignKey("ToPlaceId");

                    b.Navigation("CabType");

                    b.Navigation("FromPlace");

                    b.Navigation("ToPlace");
                });

            modelBuilder.Entity("CabBooking.Core.Entities.BookingHistory", b =>
                {
                    b.HasOne("CabBooking.Core.Entities.CabType", "CabType")
                        .WithMany("BookingHistories")
                        .HasForeignKey("CabTypeId");

                    b.HasOne("CabBooking.Core.Entities.Place", "FromPlace")
                        .WithMany("FromBookingHistories")
                        .HasForeignKey("FromPlaceId");

                    b.HasOne("CabBooking.Core.Entities.Place", "ToPlace")
                        .WithMany("ToBookingHistories")
                        .HasForeignKey("ToPlaceId");

                    b.Navigation("CabType");

                    b.Navigation("FromPlace");

                    b.Navigation("ToPlace");
                });

            modelBuilder.Entity("CabBooking.Core.Entities.CabType", b =>
                {
                    b.Navigation("BookingHistories");

                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("CabBooking.Core.Entities.Place", b =>
                {
                    b.Navigation("FromBookingHistories");

                    b.Navigation("FromBookings");

                    b.Navigation("ToBookingHistories");

                    b.Navigation("ToBookings");
                });
#pragma warning restore 612, 618
        }
    }
}
