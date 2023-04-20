using OneSkate.Web.Dtos;
using System.Collections.Generic;

namespace OneSkate.Web.Models
{
    public class Racer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Club Club { get; set; }
        public int? ClubId { get; set; }
        public IEnumerable<RacerRace> Races { get; set; }
        public ICollection<Result> Results { get; set; }

    }
}