using Microsoft.AspNetCore.Identity;

namespace Events.core.models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Booking>? Bookings { get; set; }

    }
}
