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
        public List<int> Ranks { get; set; }
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
                }
            }
        }
        public IActionResult OnPost(int id)
        {
            Race = _raceService.GetById(id);
            var results = Race.Results.ToList();
            var racers = Race.Racers.ToList();

            if (results.Count == 0)
            {
                for (int i = 0; i < racers.Count; i++)
                {
                    ResultGetDto resultDto = new()
                    {
                        RacerId = racers[i].Id,
                        RaceId = Race.Id,
                        RacerName = racers[i].Name,
                        Rank = Ranks[i],
                    };
                    Race.Results.Add(resultDto);
                }
            }
            else
            {
                for (int i = 0; i < racers.Count; i++)
                {
                    results[i].Rank = Ranks[i];
                }
                Race.Results = results;
            }
            _raceService.Update(Race.Id, Race);
            return RedirectToPage("Results", new { id = Race.Id });
        }

    }
}
