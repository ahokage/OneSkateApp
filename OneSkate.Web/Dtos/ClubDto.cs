using System.ComponentModel.DataAnnotations;

namespace OneSkate.Web.Dtos
{
    public class ClubDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }
    }
}
