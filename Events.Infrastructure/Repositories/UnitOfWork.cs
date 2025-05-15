using Events.core.Interfaces;
using WebApp.Core.Interfaces;
using WebApp.Infrastructure.persistence;

namespace WebApp.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;


        public UnitOfWork(AppDbContext context,
            IBookingRepo bookingRepo,
            IEventRepo eventRepo
           )
        {
            _context = context;
            EventRepo = eventRepo;
            BookingRepo = bookingRepo;

        }

        public IEventRepo EventRepo { get; private set; } = null!;
        public IBookingRepo BookingRepo { get; private set; } = null!;

        public void Dispose() => _context.Dispose();
        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

    }
}
