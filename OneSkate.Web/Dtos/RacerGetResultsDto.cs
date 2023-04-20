using System.Collections;
using System.Collections.Generic;

namespace OneSkate.Web.Dtos
{
    public class RacerGetResultsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int? ClubId { get; set; }
        public ICollection<ResultRacerGetDto> Results { get; set; }
    }
}
