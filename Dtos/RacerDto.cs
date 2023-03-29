using OneSkate.Models;
using System.Collections.Generic;

namespace OneSkate.Dtos
{
    public class RacerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public ClubDto Club { get; set; }
        public int? ClubId { get; set; }
        public RaceDto Race { get; set; }
        public int? RaceId { get; set; }
    }
}
