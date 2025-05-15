using Events.core.models;
using WebApp.Core.Interfaces;

namespace WebApp.Application.Services
{
    public class BookingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<bool> AddAsync(int eventId , string userId)
        {

            var booking = await _unitOfWork.BookingRepo
                .GetAsync(b => b.EventId == eventId && b.UserId == userId);

            if (booking != null)
                return false;

            var newBooking = new Booking
            {
                EventId = eventId,
                UserId = userId,
            };

            await _unitOfWork.BookingRepo.AddAsync(newBooking);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }


        public async Task RemoveAsync(int id)
        {
            var Booking = await _unitOfWork.BookingRepo.GetAsync(c => c.Id == id);
            _unitOfWork.BookingRepo.Remove(Booking);
            await _unitOfWork.SaveChangesAsync();
        }
    
    
        public async Task<List<int>> GetUserBookedEventIdsAsync(string userId) => 
            await _unitOfWork.BookingRepo.GetUserBookedEventIdsAsync(userId);
          
    
    
    }



}
