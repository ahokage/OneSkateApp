using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OneSkate.Web.Dtos;
using OneSkate.Web.Interfaces;

namespace OneSkate.Web.Pages.Venues
{
    public class EditModel : PageModel
    {
        private readonly IVenueService _venueService;
        public EditModel(IVenueService venueService)
        {
            _venueService = venueService;
        }
        [BindProperty]
        public VenueDto Venue { get; set; }

        public void OnGet()
        {
        }
        public IActionResult OnPost(int id)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            _venueService.Update(id, Venue);
            return RedirectToPage("Display");
        }
    }
}
