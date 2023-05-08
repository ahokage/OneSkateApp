using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OneSkate.Web.Dtos;
using OneSkate.Web.Interfaces;

namespace OneSkate.Web.Pages.Races
{
    public class EditModel : PageModel
    {
        private readonly IRaceService _raceService;
        private readonly IVenueService _venueService;
        private readonly IRacerService _racerService;
        public EditModel(IRaceService raceService, IVenueService venueService, IRacerService racerService)
        {
            _raceService = raceService;
            _venueService = venueService;
            _racerService = racerService;
        }
        public List<SelectListItem> ListItems = new List<SelectListItem>();
        public List<SelectListItem> RacersList = new List<SelectListItem>();

        [BindProperty]
        public List<string> SelectedIds { get; set; }
        public IEnumerable<VenueDto> Venues { get; set; }
        public IEnumerable<RacerDto> Racers { get; set; }
        [BindProperty]
        public RaceDto Race { get; set; }

        public void OnGet()
        {
            Venues = _venueService.GetAll();
            Racers = _racerService.GetAll();
            foreach (var venue in Venues)
            {
                ListItems.Add(new SelectListItem
                {
                    Text = venue.Name,
                    Value = venue.Id.ToString()
                });
            }
            foreach (var racer in Racers)
            {
                RacersList.Add(new SelectListItem
                {
                    Value = racer.Id.ToString(),
                    Text = racer.Name
                });
            }
        }
        public IActionResult OnPost(int id)
        {
            Race.Racers = new List<RacerDto>(SelectedIds.Select(x => new RacerDto { Id = Convert.ToInt32(x) }));
            _raceService.Update(id, Race);
            return RedirectToPage("Display");
        }
    }
}
