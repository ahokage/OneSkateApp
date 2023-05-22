using System.ComponentModel.DataAnnotations;

namespace OneSkate.Web.Dtos
{
    public class ResultGetDto
    {
        public int RaceId { get; set; }
        public string RacerName { get; set; }
        public int RacerId { get; set; }
        [Required]
        public int Rank { get; set; }
    }
}
