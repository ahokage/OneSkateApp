using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OneSkate.Web.Dtos;
using OneSkate.Web.Interfaces;

namespace OneSkate.Web.Pages.Racers
{
    public class CreateModel : PageModel
    {
        private readonly IRacerService _racerService;
        private readonly IClubService _clubService;
        public CreateModel(IRacerService racerService, IClubService clubService)
        {
            _racerService = racerService;
            _clubService = clubService;
        }
        [BindProperty]
        public RacerDto Racer { get; set; }
        public List<SelectListItem> ListItems { get; set; } = new();

        public void OnGet()
        {
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
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                var clubs = _clubService.GetAll();

                foreach (var club in clubs)
                {
                    ListItems.Add(new SelectListItem
                    {
                        Text = club.Name,
                        Value = club.Id.ToString()
                    });
                }

                return Page();
            }
            _racerService.Create(Racer);
            return RedirectToPage("Display");
        }
    }
}
