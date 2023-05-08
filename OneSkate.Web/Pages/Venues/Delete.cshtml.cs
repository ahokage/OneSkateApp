using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OneSkate.Web.Dtos;
using OneSkate.Web.Interfaces;

namespace OneSkate.Web.Pages.Venues
{
    public class DeleteModel : PageModel
    {
        private readonly IVenueService _venueService;
        public DeleteModel(IVenueService venueService)
        {
            _venueService = venueService;
        }
        [BindProperty]
        public VenueDto Venue { get; set; }
        public IActionResult OnGet(int id)
        {
            _venueService.Delete(id);
            return RedirectToPage("Display");
        }
    }
}
