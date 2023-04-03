using OneSkate.Models;
using System.Collections.Generic;

namespace OneSkate.Dtos
{
    public class RacerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int? ClubId { get; set; }
        public ICollection<RacerRaceDto> Racers { get;set; }
    }
}
