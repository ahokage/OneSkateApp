using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OneSkate.Web.Dtos;
using OneSkate.Web.Interfaces;

namespace OneSkate.Web.Pages.Races
{
    public class ResultsModel : PageModel
    {
        private readonly IRaceService _raceService;
        public ResultsModel(IRaceService raceService)
        {
            _raceService = raceService;
        }
        [BindProperty]
        public List<ResultGetDto> Results { get; set; }
        [BindProperty]
        public RaceDto Race { get; set; }
        public void OnGet(int id)
        {
            Race = _raceService.GetById(id);
            Results = Race.Results.ToList();

            if (Race.Results.Count == 0)
            {
                foreach (var racer in Race.Racers)
                {
                    ResultGetDto resultDto = new()
                    {
                        RacerId = racer.Id,
                        RaceId = Race.Id,
                        RacerName = racer.Name

                    };
                    Race.Results.Add(resultDto);
                    Results.Add(resultDto);
                }
                _raceService.Update(Race.Id, Race);
            }
        }
        public IActionResult OnPost(int id)
        {
            Race = _raceService.GetById(id);
            var results = Results.ToList();
            var racers = Race.Racers.ToList();
            var count = 0;
            List<int> ranks = new();

            for (int i = 1; i <= results.Count; i++) { ranks.Add(i); }

            foreach (var result in results) { ranks.Add(result.Rank); }

            for (int i = 0; i < ranks.Count; i++)
            {
                for (int j = 0; j < ranks.Count; j++)
                {
                    if (ranks[i] == ranks[j])
                    {
                        count++;
                    }
                }
                if (count != 2)
                {
                    ModelState.AddModelError("", "Cannot have negative, 0, duplicate or untaken rankings!");
                    Results = Race.Results.ToList();
                    return Page();
                }
                count = 0;
            }

            Results.Clear();
            for (int i = 0; i < racers.Count; i++)
            {
                ResultGetDto resultDto = new()
                {
                    RacerId = racers[i].Id,
                    RaceId = Race.Id,
                    RacerName = racers[i].Name,
                    Rank = results[i].Rank
                };
                Results.Add(resultDto);
                Race.Results.Add(resultDto);
            }

            Race.Results = Results;
            _raceService.Update(Race.Id, Race);
            return RedirectToPage("Display");
        }

    }
}
