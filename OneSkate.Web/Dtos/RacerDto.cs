using OneSkate.Web.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OneSkate.Web.Dtos
{
    public class RacerDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public int? ClubId { get; set; }
    }
}
