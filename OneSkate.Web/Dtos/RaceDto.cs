using OneSkate.Web.Models;
using System.Collections.Generic;
using System;

namespace OneSkate.Web.Dtos
{
    public class RaceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int VenueId { get; set; }
        public DateTime Date { get; set; }
        public ICollection<RacerDto> Racers { get; set; }
        public ICollection<ResultDto> Results { get; set; }
    }
}
