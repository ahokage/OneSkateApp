using System.Collections;
using System.Collections.Generic;

namespace OneSkate.Web.Models
{
    public class RacerRace
    {
        public Race Race { get; set; }
        public int RaceId { get; set; }
        public Racer Racer { get; set;}
        public int RacerId { get; set;}
    }
}
