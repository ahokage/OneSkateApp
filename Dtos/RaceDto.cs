using OneSkate.Models;
using System.Collections.Generic;
using System;

namespace OneSkate.Dtos
{
    public class RaceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public VenueDto Venue { get; set; }
        public int VenueId { get; set; }
        public DateTime Date { get; set; }
        public ICollection<RacerGetDto> Racers { get; set; }
        public ICollection<ResultDto> Results { get; set; }
    }
}
