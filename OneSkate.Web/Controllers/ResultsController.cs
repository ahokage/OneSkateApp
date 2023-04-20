using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using OneSkate.Web.Dtos;
using OneSkate.Web.Interfaces;
using System.Collections.Generic;

namespace OneSkate.Web.Controllers
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
    }
}
