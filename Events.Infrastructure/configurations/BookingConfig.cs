using Events.core.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApp.Infrastructure.configurations
{
    public class BookingConfig : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasIndex(b => new { b.UserId, b.EventId }).IsUnique();

            builder.HasOne(b => b.User)
             .WithMany(au => au.Bookings)
             .HasForeignKey(b => b.UserId);

        }

    }



}
