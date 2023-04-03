using System.Collections.Generic;
using System;
using OneSkate.Models;

namespace OneSkate.Dtos
{
    public class RaceGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int VenueId { get; set; }
        public DateTime Date { get; set; }
        public ICollection<RacerGetDto> Racers { get; set; }
        public ICollection<ResultDto> Results { get; set; }
    }
}
