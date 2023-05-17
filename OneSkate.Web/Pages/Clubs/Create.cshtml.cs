using Azure;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Storage;
using OneSkate.Web.Data;
using OneSkate.Web.Dtos;
using OneSkate.Web.Interfaces;
using OneSkate.Web.Models;
using OneSkate.Web.Pages.Clubs;
using System.Diagnostics;

namespace OneSkate.Web.Pages
{
    public class ClubsModel : PageModel
    {
        private readonly IClubService _clubService;
        public ClubsModel(IClubService clubService)
        {
            _clubService = clubService;
        }
        public IEnumerable<ClubDto> Clubs { get; set; } 
        [BindProperty]
        public ClubDto Club { get; set; }

        public void OnGet()
        {

            Clubs = _clubService.GetAll();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Clubs = _clubService.GetAll();
                return Page();
            }
            _clubService.Create(Club);
            return RedirectToPage();
        }

    }
}
