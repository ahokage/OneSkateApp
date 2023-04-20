using OneSkate.Web.Models;
using System.Collections.Generic;

namespace OneSkate.Web.Dtos
{
    public class RacerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int? ClubId { get; set; }
    }
}
