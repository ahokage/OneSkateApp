using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OneSkate.Web.Dtos;
using OneSkate.Web.Interfaces;

namespace OneSkate.Web.Pages.Venues
{
    public class CreateModel : PageModel
    {
        private readonly IVenueService _venueService;
        public CreateModel(IVenueService venueService)
        {
            _venueService = venueService;
        }
        [BindProperty]
        public VenueDto Venue { get; set; }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _venueService.Create(Venue);
            return RedirectToPage("Display");
        }
    }
}
