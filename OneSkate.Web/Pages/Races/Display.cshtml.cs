using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OneSkate.Web.Dtos;
using OneSkate.Web.Interfaces;

namespace OneSkate.Web.Pages.Races
{
    public class DisplayModel : PageModel
    {
        private readonly IRaceService _raceservice;
        private readonly IVenueService _venueservice;
        public DisplayModel(IRaceService raceservice, IVenueService venueservice)
        {
            _raceservice = raceservice;
            _venueservice = venueservice;
        }
        public IEnumerable<RaceGetDto> Races { get; set; }
        public List<SelectListItem> ListItems { get; set; } = new List<SelectListItem>();


        public void OnGet()
        {
            Races =_raceservice.GetAll();
            var venues = _venueservice.GetAll();
            foreach(var venue in venues )
            {
                ListItems.Add(new SelectListItem
                {
                    Text = venue.Name,
                    Value = venue.Id.ToString(),
                });
            }
        }
    }
}
