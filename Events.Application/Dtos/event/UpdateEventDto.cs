﻿namespace Events.Application.Dtos
{
    public class UpdateEventDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Category { get; set; } = default!;
        public string Venue { get; set; } = default!;
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public string? imagePath { get; set; }

    }
}
