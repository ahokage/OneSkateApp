using AutoMapper;
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
        private readonly IMapper _mapper;
        public EditModel(IRaceService raceService, IVenueService venueService, IRacerService racerService,IMapper mapper)
        {
            _raceService = raceService;
            _venueService = venueService;
            _racerService = racerService;
            _mapper = mapper;
        }
        public List<SelectListItem> ListItems = new();
        public List<SelectListItem> RacersList = new();

        [BindProperty]
        public List<string> SelectedIds { get; set; }
        public IEnumerable<VenueDto> Venues { get; set; }
        public IEnumerable<RacerDto> Racers { get; set; }
        [BindProperty]
        public RaceDto Race { get; set; }

        public IActionResult OnGet(int id)
        {
            Race = _raceService.GetById(id);

            SelectedIds = Race.Racers.Select(x => x.Id.ToString()).ToList();

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

            return Page();
        }
        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                Race = _raceService.GetById(id);

                SelectedIds = Race.Racers.Select(x => x.Id.ToString()).ToList();

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
                return Page();
            }
            Race.Racers = new List<RacerDto>(SelectedIds.Select(x => new RacerDto { Id = Convert.ToInt32(x) }));
            var race = _mapper.Map<RaceDto>(Race);
            _raceService.Update(id , race);
            return RedirectToPage("Display");
        }
    }
}
