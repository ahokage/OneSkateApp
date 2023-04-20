using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneSkate.Web.Dtos;
using OneSkate.Web.Interfaces;
using System.Collections;
using System.Collections.Generic;

namespace OneSkate.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RacesController : ControllerBase
    {
        private readonly IRaceService _raceService;

        public RacesController(IRaceService raceService)
        {
            _raceService = raceService;
        }
        [HttpGet]
        public IEnumerable<RaceGetDto> GetAll() 
        {
            return _raceService.GetAll();
        }
        [HttpGet("{id}")]
        public RaceGetDto GetById(int id) 
        {
            return _raceService.GetById(id);
        }
        [HttpPost]
        public RaceDto Create(RaceDto raceDto)
        {
            return _raceService.Create(raceDto);
        }
        [HttpDelete]
        public void Delete(int id) 
        {
            _raceService.Delete(id);
        }
        [HttpPut]
        public void Update(int id, RaceDto raceDto)
        {
            _raceService.Update(id, raceDto);
        }
    }
}
