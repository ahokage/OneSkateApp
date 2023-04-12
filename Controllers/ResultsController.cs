using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using OneSkate.Dtos;
using OneSkate.Interfaces;
using System.Collections.Generic;

namespace OneSkate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultsController : ControllerBase
    {
        private readonly IResultService _resultService;
        public ResultsController(IResultService resultService)
        { 
            _resultService = resultService;
        }
        [HttpGet]
        public IEnumerable<ResultGetDto> GetAll()
        {
            return _resultService.GetAll();
        }
        [HttpGet("RaceResults{id}")]
        public RaceGetDto RaceById(int id)
        {
            return _resultService.RaceById(id);
        }
        [HttpGet("RacerResults{id}")]
        public RacerGetResultsDto RacerById(int id)
        {
            return _resultService.RacerById(id);
        }
        [HttpPost]
        public ResultDto Create(ResultDto resultDto)
        {
            return _resultService.Create(resultDto);
        }
    }
}
