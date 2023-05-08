using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OneSkate.Web.Dtos;
using OneSkate.Web.Interfaces;

namespace OneSkate.Web.Pages.Racers
{
    public class DisplayModel : PageModel
    {
        private readonly IRacerService _racerService;
        private readonly IClubService _clubService;
        public List<SelectListItem> ListItems { get; set; } = new List<SelectListItem>();

        public DisplayModel(IRacerService racerService, IClubService clubService)
        {
            _racerService = racerService;
            _clubService = clubService;
        }
        public IEnumerable<RacerDto> Racers { get; set; }
        [BindProperty]
        public RacerDto Racer { get; set; }


        public void OnGet()
        {
            Racers = _racerService.GetAll();
            var clubs = _clubService.GetAll();

            foreach (var club in clubs)
            {
                ListItems.Add(new SelectListItem
                {
                    Text = club.Name,
                    Value = club.Id.ToString()
                });
            }
        }
    }
}
