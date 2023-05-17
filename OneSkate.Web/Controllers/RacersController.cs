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
    public class RacersController : ControllerBase
    {
        private readonly IRacerService _racerService;

        public RacersController(IRacerService racerService)
        {
            _racerService = racerService;
        }
        [HttpGet]
        public IEnumerable<RacerDto> GetAll()
        {
            return _racerService.GetAll();
        }
        [HttpGet("{id}")]
        public RacerDto GetById(int id)
        {
            return _racerService.GetById(id);
        }
        [HttpPost]
        public RacerDto Create(RacerDto racerdto)
        {
            return _racerService.Create(racerdto);
        }
        [HttpDelete]
        public void Delete(int id) 
        {
            _racerService.Delete(id);
        }
        [HttpPut]
        public void Update(int id, RacerDto RacerDto)
        {
            _racerService.Update(id, RacerDto);
        }
        //[HttpPost]
        //public List<RacerDto> CreateMany(List<RacerDto> racers)
        //{
        //    foreach(var racer in racers)
        //    {
        //        _racerService.Create(racer);
        //    }
        //    return racers;
        //}
    }
}
