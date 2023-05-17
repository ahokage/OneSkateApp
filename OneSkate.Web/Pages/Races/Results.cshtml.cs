using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OneSkate.Web.Dtos;
using OneSkate.Web.Interfaces;

namespace OneSkate.Web.Pages.Races
{
    public class ResultsModel : PageModel
    {
        private readonly IResultService _resultService;
        private readonly IRaceService _raceService;
        public ResultsModel(IResultService resultService, IRaceService raceService)
        {
            _resultService = resultService;
            _raceService = raceService;
        }
        public List<SelectListItem> ListItems { get; set; } = new List<SelectListItem>();
        public IEnumerable<ResultGetDto> Results { get; set; }

        public RaceDto Race { get; set; }
        public void OnGet(int id)
        { 
            Race = _raceService.GetById(id);
            Results =_resultService.GetAll();

            foreach (var result in Results)
            {
                if(result.RaceId == id)
                {
                    ListItems.Add(new SelectListItem
                    {
                        Text = result.RacerName,
                        Value = result.Rank.ToString()
                    });
                }                
            }
        }
    }
}
