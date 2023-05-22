using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OneSkate.Web.Dtos;
using OneSkate.Web.Interfaces;
using OneSkate.Web.Models;
using System.ComponentModel.DataAnnotations;

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
            var racerscount = 0;
            for(int i=0; i<results.Count; i++)
            {
                for(int j = i+1;j < results.Count; j++)
                {
                    if (results[i].Rank == results[j].Rank)
                    {
                        ModelState.AddModelError("", "Cannot have negative, 0, duplicate or untaken rankings!");
                        Results = Race.Results.ToList();
                        return Page();
                    }
                }
                if (results[i].Rank < 1 || results[i].Rank>results.Count)
                {
                    ModelState.AddModelError("", "Cannot have negative, 0, duplicate or untaken rankings!");
                    Results = Race.Results.ToList();
                    return Page();
                }
                racerscount += i + 1;
                count += results[i].Rank;
            }

            if (count != racerscount)
            {
                ModelState.AddModelError("", "Cannot have negative, 0, duplicate or untaken rankings!");
                Results = Race.Results.ToList();
                return Page();
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
            return RedirectToPage("Results", new { id = Race.Id });
        }

    }
}
