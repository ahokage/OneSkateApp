using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OneSkate.Web.Dtos;
using OneSkate.Web.Interfaces;

namespace OneSkate.Web.Pages.Races
{
    public class CreateModel : PageModel
    {
        private readonly IRaceService _raceService;
        private readonly IVenueService _venueService;
        private readonly IRacerService _racerService;
        public CreateModel(IRaceService raceService, IVenueService venueService,IRacerService racerService)
        {
            _racerService = racerService;
            _raceService = raceService;
            _venueService = venueService;
        }
        public IEnumerable<VenueDto> Venues { get; set; }
        public IEnumerable<RacerDto> Racers { get; set; }
        [BindProperty]
        public List<string> SelectedIds { get; set; }
        public List<SelectListItem> ListItems = new List<SelectListItem>();
        public List<SelectListItem> RacersList = new List<SelectListItem>();

        [BindProperty]
        public RaceDto Race { get; set; }
        public void OnGet()
        {
            Venues =_venueService.GetAll();
            Racers = _racerService.GetAll();
            foreach (var venue in Venues)
            {
                ListItems.Add(new SelectListItem
                {
                    Text = venue.Name,
                    Value = venue.Id.ToString()
                });
            }
            foreach(var racer in Racers)
            {
                RacersList.Add(new SelectListItem
                {
                    Value = racer.Id.ToString(),
                    Text = racer.Name
                });
            }
        }
        public IActionResult OnPost() 
        {
            Race.Racers = new List<RacerDto>(SelectedIds.Select(x => new RacerDto { Id = Convert.ToInt32(x) }));
            _raceService.Create(Race);
            return RedirectToPage("Display");
        }
    }
}
