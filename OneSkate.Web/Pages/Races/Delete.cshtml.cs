using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OneSkate.Web.Dtos;
using OneSkate.Web.Interfaces;

namespace OneSkate.Web.Pages.Races
{
    public class DeleteModel : PageModel
    {
        private readonly IRaceService _raceService;
        public DeleteModel(IRaceService raceService)
        {
            _raceService = raceService;
        }
        public RaceDto Race { get; set; }
        public IActionResult OnGet(int id)
        {
            _raceService.Delete(id);
            return RedirectToPage("Display");
        }
    }
}
