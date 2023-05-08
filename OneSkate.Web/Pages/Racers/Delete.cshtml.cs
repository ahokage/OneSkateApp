using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OneSkate.Web.Dtos;
using OneSkate.Web.Interfaces;
using OneSkate.Web.Models;

namespace OneSkate.Web.Pages.Racers
{
    public class DeleteModel : PageModel
    {
        private readonly IRacerService _racerService;
        public DeleteModel(IRacerService racerService)
        {
            _racerService = racerService;
        }

        public RacerDto Racer { get; set; }
        public IActionResult OnGet(int id)
        {
            _racerService.Delete(id);
            return RedirectToPage("DIsplay");
        }
    }
}
