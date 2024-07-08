using Microsoft.EntityFrameworkCore;
using City = TravelAndAccommodationBookingPlatform.Db.Models.City;
using Hotel = TravelAndAccommodationBookingPlatform.Db.Models.Hotel;
using Reservation = TravelAndAccommodationBookingPlatform.Db.Models.Reservation;
using Room = TravelAndAccommodationBookingPlatform.Db.Models.Room;
using User = TravelAndAccommodationBookingPlatform.Db.Models.User;

namespace TravelAndAccommodationBookingPlatform.Db.Data;

public class HotelsBookingSystemContext : DbContext
{
    public HotelsBookingSystemContext(DbContextOptions<HotelsBookingSystemContext> options)
        : base(options) {}

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__City__3214EC27AB428730");

            entity.ToTable("City");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PostOffice)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Post_Office");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Hotel__3214EC27FB92D2E5");

            entity.ToTable("Hotel");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CityId).HasColumnName("City_ID");
            entity.Property(e => e.MaxPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Max_price");
            entity.Property(e => e.MinPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Min_price");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Owner)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StarRating).HasColumnName("Star_Rating");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.City).WithMany(p => p.Hotels)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK__Hotel__City_ID__398D8EEE");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reservat__3214EC27D62B486B");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Discount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.EndDate).HasColumnName("End_date");
            entity.Property(e => e.HotelId).HasColumnName("Hotel_ID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.RoomId).HasColumnName("Room_ID");
            entity.Property(e => e.StartDate).HasColumnName("Start_date");
            entity.Property(e => e.UserId).HasColumnName("User_ID");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.HotelId)
                .HasConstraintName("FK__Reservati__Hotel__4222D4EF");

            entity.HasOne(d => d.Room).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__Reservati__Room___4316F928");

            entity.HasOne(d => d.User).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Reservati__User___412EB0B6");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Room__3214EC278E7FF14A");

            entity.ToTable("Room");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.RoomId)
                .HasMaxLength(10)
                .HasColumnName("Room_Number");
            entity.Property(e => e.AdultsCount).HasColumnName("Adults_count");
            entity.Property(e => e.Availability)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ChildrenCount).HasColumnName("Children_count");
            entity.Property(e => e.HotelId).HasColumnName("Hotel_ID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.HotelId).OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK__Room__Hotel_ID__3C69FB99");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC27606C6153");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PassportId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Passport_ID");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Phone_number");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);
        });
    }

}
