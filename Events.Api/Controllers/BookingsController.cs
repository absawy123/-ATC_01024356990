using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApp.Application.Services;

namespace Events.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly BookingService _bookingService;
        public BookingsController(BookingService bookingService) 
        {
            _bookingService = bookingService;
        }



        [HttpPost("BookEvent/{eventId}")]
        public async Task<ActionResult> AddAsync(int eventId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            if (userId == null)
                return BadRequest("You are not logged in");

            var added = await _bookingService.AddAsync(eventId, userId);
            if (added)
                return Ok(new {Success =true});

            else return BadRequest(new { Success = false, Message = "You already booked this event" });
        }

        




    }
}
