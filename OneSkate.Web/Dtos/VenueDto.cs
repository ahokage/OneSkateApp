using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace OneSkate.Web.Dtos
{
    public class VenueDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Required")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Required")]
        public string Notes { get; set; }
    }
}
