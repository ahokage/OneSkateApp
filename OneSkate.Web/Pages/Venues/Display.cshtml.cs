using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OneSkate.Web.Dtos;
using OneSkate.Web.Interfaces;

namespace OneSkate.Web.Pages.Venues
{
    public class DisplayModel : PageModel
    {
        private readonly IVenueService _venueService;
        public DisplayModel(IVenueService venueService)
        {
            _venueService = venueService;
        }
        public IEnumerable<VenueDto> Venues { get; set; }
        [BindProperty]
        public VenueDto Venue { get; set; }

        public void OnGet()
        {
            Venues =_venueService.GetAll();
        }
        public IActionResult OnPost()
        {
            _venueService.Create(Venue);
            return RedirectToPage("Display");
        }
    }
}
