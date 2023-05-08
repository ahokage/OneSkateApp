using System.ComponentModel.DataAnnotations;

namespace OneSkate.Web.Models
{
    public class Venue
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Notes { get; set; }
    }
}
