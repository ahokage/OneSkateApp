using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OneSkate.Web.Dtos;
using OneSkate.Web.Interfaces;

namespace OneSkate.Web.Pages.Clubs
{
    public class EditModel : PageModel
    {
        private readonly IClubService _clubService;
        public EditModel(IClubService clubService)
        {
            _clubService = clubService;
        }
        [BindProperty]
        public ClubDto Club { get; set; }

        public IActionResult OnGet(int id)
        {
            Club = _clubService.GetById(id);
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _clubService.Update(id,Club);
            return RedirectToPage("Create");
        }
    }
}
