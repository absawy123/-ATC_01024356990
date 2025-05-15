using Events.core.models;
using WebApp.Core.Interfaces;

namespace Events.core.Interfaces
{
    public interface IBookingRepo :IGenericRepo<Booking>
    {
        Task<List<int>> GetUserBookedEventIdsAsync(string userId);
    }
}
