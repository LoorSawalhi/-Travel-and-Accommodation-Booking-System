﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelAndAccommodationBookingPlatform.Db.Models;

#nullable disable

namespace TravelAndAccommodationBookingPlatform.Db.Migrations
{
    [DbContext(typeof(HotelsBookingSystemContext))]
    [Migration("20240707082418_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Db.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PostOffice")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Post_Office");

                    b.HasKey("Id")
                        .HasName("PK__City__3214EC27AB428730");

                    b.ToTable("City", (string)null);
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Db.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<int?>("CityId")
                        .HasColumnType("int")
                        .HasColumnName("City_ID");

                    b.Property<decimal?>("MaxPrice")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("Max_price");

                    b.Property<decimal?>("MinPrice")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("Min_price");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Owner")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("StarRating")
                        .HasColumnType("int")
                        .HasColumnName("Star_Rating");

                    b.Property<string>("Type")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PK__Hotel__3214EC27FB92D2E5");

                    b.HasIndex("CityId");

                    b.ToTable("Hotel", (string)null);
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Db.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<decimal?>("Discount")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<DateOnly?>("EndDate")
                        .HasColumnType("date")
                        .HasColumnName("End_date");

                    b.Property<int?>("HotelId")
                        .HasColumnType("int")
                        .HasColumnName("Hotel_ID");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int")
                        .HasColumnName("Room_ID");

                    b.Property<DateOnly?>("StartDate")
                        .HasColumnType("date")
                        .HasColumnName("Start_date");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("User_ID");

                    b.HasKey("Id")
                        .HasName("PK__Reservat__3214EC27D62B486B");

                    b.HasIndex("HotelId");

                    b.HasIndex("RoomId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Db.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<int?>("AdultsCount")
                        .HasColumnType("int")
                        .HasColumnName("Adults_count");

                    b.Property<string>("Availability")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("ChildrenCount")
                        .HasColumnType("int")
                        .HasColumnName("Children_count");

                    b.Property<int?>("HotelId")
                        .HasColumnType("int")
                        .HasColumnName("Hotel_ID");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("Id")
                        .HasName("PK__Room__3214EC278E7FF14A");

                    b.HasIndex("HotelId");

                    b.ToTable("Room", (string)null);
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Db.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PassportId")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Passport_ID");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Phone_number");

                    b.Property<string>("Role")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PK__Users__3214EC27606C6153");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Db.Models.Hotel", b =>
                {
                    b.HasOne("TravelAndAccommodationBookingPlatform.Db.Models.City", "City")
                        .WithMany("Hotels")
                        .HasForeignKey("CityId")
                        .HasConstraintName("FK__Hotel__City_ID__398D8EEE");

                    b.Navigation("City");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Db.Models.Reservation", b =>
                {
                    b.HasOne("TravelAndAccommodationBookingPlatform.Db.Models.Hotel", "Hotel")
                        .WithMany("Reservations")
                        .HasForeignKey("HotelId")
                        .HasConstraintName("FK__Reservati__Hotel__4222D4EF");

                    b.HasOne("TravelAndAccommodationBookingPlatform.Db.Models.Room", "Room")
                        .WithMany("Reservations")
                        .HasForeignKey("RoomId")
                        .HasConstraintName("FK__Reservati__Room___4316F928");

                    b.HasOne("TravelAndAccommodationBookingPlatform.Db.Models.User", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Reservati__User___412EB0B6");

                    b.Navigation("Hotel");

                    b.Navigation("Room");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Db.Models.Room", b =>
                {
                    b.HasOne("TravelAndAccommodationBookingPlatform.Db.Models.Hotel", "Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("HotelId")
                        .HasConstraintName("FK__Room__Hotel_ID__3C69FB99");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Db.Models.City", b =>
                {
                    b.Navigation("Hotels");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Db.Models.Hotel", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Db.Models.Room", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Db.Models.User", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
