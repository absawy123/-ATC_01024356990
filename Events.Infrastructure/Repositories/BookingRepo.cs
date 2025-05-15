using Events.core.Interfaces;
using Events.core.models;
using Microsoft.EntityFrameworkCore;
using WebApp.Infrastructure.persistence;

namespace WebApp.Infrastructure.Repositories
{
    public class BookingRepo : GenericRepo<Booking> ,IBookingRepo
    {
        private readonly AppDbContext _context;
        public BookingRepo(AppDbContext context):base(context) 
        {
            _context = context;
        }

        public async Task<List<int>> GetUserBookedEventIdsAsync(string userId)
        {
            return await _context.Bookings
                .Where(b => b.UserId == userId)
                .Select(b => b.EventId)
                .ToListAsync();
        }



    }
}
