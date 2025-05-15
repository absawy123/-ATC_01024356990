using Events.core.Interfaces;

namespace WebApp.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IBookingRepo BookingRepo { get; }
        public IEventRepo EventRepo { get; }    
        
        Task<int> SaveChangesAsync();


    }
}
