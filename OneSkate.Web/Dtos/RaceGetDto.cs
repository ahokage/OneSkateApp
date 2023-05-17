using System.Collections.Generic;
using System;
using OneSkate.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace OneSkate.Web.Dtos
{
    public class RaceGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int VenueId { get; set; }
        public DateTime Date { get; set; }
        public ICollection<RacerDto> Racers { get; set; }
        public ICollection<ResultGetDto> Results { get; set; }
    }
}
