
namespace Events.core.models
{
    public class Event 
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Category { get; set; } = default!;
        public string Venue { get; set; } = default!;
        public decimal Price { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string imagePath { get; set; } = default!;
      
        public ICollection<Booking>? Bookings { get; set; } = default!;

    }
}
