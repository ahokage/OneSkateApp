using System;
using System.Collections.Generic;

namespace OneSkate.Models
{
    public class Race
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Venue Venue { get; set; }
        public int VenueId { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Racer> Racers { get; set; }
        public ICollection<Result> Results { get; set; }
    }
}
