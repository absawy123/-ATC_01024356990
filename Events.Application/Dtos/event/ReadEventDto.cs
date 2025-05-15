using Microsoft.AspNetCore.Http;

namespace Events.Application.Dtos
{
    public class ReadEventDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Category { get; set; } = default!;
        public DateTime Date { get; set; }
        public string Venue { get; set; } = default!;
        public decimal Price { get; set; }
        public string ImagePath { get; set; } = default!;
        public bool IsBooked { get; set; }
    }
}
