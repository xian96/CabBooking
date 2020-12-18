using CabBooking.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CabBooking.Infrastructure.Data
{
    public class CabBookingDbContext : DbContext
    {
        //constructor wiht dipendency injection
        public CabBookingDbContext(DbContextOptions<CabBookingDbContext> options) : base(options)
        {
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingHistory> BookingHistories { get; set; }
        public DbSet<CabType> CabTypes { get; set; }
        public DbSet<Place> Places { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(ConfigureBooking);
            modelBuilder.Entity<BookingHistory>(ConfigureBookingHistory);
            modelBuilder.Entity<CabType>(ConfigureCabType);
            modelBuilder.Entity<Place>(ConfigurePlace);

        }

        private void ConfigureBooking(EntityTypeBuilder<Booking> builder)
        {
            //place to configure out movie entity
            builder.ToTable("Booking");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Email).HasMaxLength(50);
            builder.Property(b => b.BookingTime).HasMaxLength(5);
            builder.Property(b => b.PickupAddress).HasMaxLength(200);
            builder.Property(b => b.Landmark).HasMaxLength(30);
            builder.Property(b => b.PickupTime).HasMaxLength(5);
            builder.Property(b => b.ContactNo).HasMaxLength(25);
            builder.Property(b => b.Status).HasMaxLength(30);
        }
        
        private void ConfigureBookingHistory(EntityTypeBuilder<BookingHistory> builder)
        {
            //place to configure out movie entity
            builder.ToTable("BookingHistory");
            builder.HasKey(bh => bh.Id);
            builder.Property(bh => bh.Email).HasMaxLength(50);
            builder.Property(bh => bh.BookingTime).HasMaxLength(5);
            builder.Property(bh => bh.PickupAddress).HasMaxLength(200);
            builder.Property(bh => bh.Landmark).HasMaxLength(30);
            builder.Property(bh => bh.PickupTime).HasMaxLength(5);
            builder.Property(bh => bh.ContactNo).HasMaxLength(25);
            builder.Property(bh => bh.Status).HasMaxLength(30);
            builder.Property(bh => bh.CompTime).HasMaxLength(5);
            builder.Property(bh => bh.FeedBack).HasMaxLength(1000);
        }

        private void ConfigureCabType(EntityTypeBuilder<CabType> builder)
        {
            //place to configure out movie entity
            builder.ToTable("CabType");
            builder.HasKey(c => c.CabTypeId);
            builder.Property(c => c.CabTypeName).HasMaxLength(30);
        }
         
        private void ConfigurePlace(EntityTypeBuilder<Place> builder)
        {
            //place to configure out movie entity
            builder.ToTable("Place");
            builder.HasKey(p => p.PlaceId);
            builder.Property(p => p.PlaceName).HasMaxLength(30);
        }
    }
}
