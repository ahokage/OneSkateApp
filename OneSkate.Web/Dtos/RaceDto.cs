using OneSkate.Web.Models;
using System.Collections.Generic;
using System;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;

namespace OneSkate.Web.Dtos
{
    public class RaceDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int VenueId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public ICollection<RacerDto> Racers { get; set; }
        public ICollection<ResultGetDto> Results { get; set; }
    }
}
