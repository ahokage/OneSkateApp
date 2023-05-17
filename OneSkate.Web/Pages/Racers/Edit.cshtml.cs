using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OneSkate.Web.Dtos;
using OneSkate.Web.Interfaces;
using System.Reflection;

namespace OneSkate.Web.Pages.Racers
{
    public class EditModel : PageModel
    {
        private readonly IRacerService _racerService;
        private readonly IClubService _clubService;
        public EditModel(IRacerService racerService, IClubService clubService)
        {
            _racerService = racerService;
            _clubService = clubService;
        }
        [BindProperty]
        public RacerDto Racer { get; set; }
        public List<SelectListItem> ListItems { get; set; } = new List<SelectListItem>();


        public IActionResult OnGet(int id)
        {
            var clubs = _clubService.GetAll();
            Racer = _racerService.GetById(id);

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
        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                var clubs = _clubService.GetAll();
                Racer = _racerService.GetById(id);

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
            _racerService.Update(id, Racer);
            return RedirectToPage("Display");
        }
    }
}
