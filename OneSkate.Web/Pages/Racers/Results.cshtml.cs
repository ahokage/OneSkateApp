using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OneSkate.Web.Dtos;
using OneSkate.Web.Interfaces;
using OneSkate.Web.Models;

namespace OneSkate.Web.Pages.Racers
{
    public class ResultsModel : PageModel
    {
        private readonly IRacerService _racerService;
        private readonly IResultService _resultService;
        public ResultsModel(IRacerService racerService,IResultService resultService)
        {
            _racerService = racerService;
            _resultService = resultService;
        }
        public List<SelectListItem> ListItems { get; set; } = new List<SelectListItem>();
        public IEnumerable<ResultRacerGetDto> Results { get; set; }
        public RacerDto Racer { get; set; }
        public void OnGet(int id)
        {
            Racer = _racerService.GetById(id);
            Results = _resultService.GetAllRaces();

            foreach (var result in Results)
            {
                if(result.Id== id)
                    ListItems.Add(new SelectListItem
                    {
                        Text = result.RaceName,
                        Value = result.Rank.ToString()
                    });                
            }
        }
    }
}
