using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OneSkate.Web.Dtos;
using OneSkate.Web.Interfaces;

namespace OneSkate.Web.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly IClubService _clubService;
        public DeleteModel(IClubService clubService)
        {
            _clubService = clubService;
        }
        [BindProperty]
        public ClubDto Club { get; set; }

        public IActionResult OnGet(int id)
        {
            _clubService.Delete(id);
            return RedirectToPage("Display");
        }
    }
}
