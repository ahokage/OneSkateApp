﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneSkate.Dtos;
using OneSkate.Interfaces;
using System.Collections;
using System.Collections.Generic;

namespace OneSkate.Controllers
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
        public IEnumerable<RacerGetDto> GetAll()
        {
            return _racerService.GetAll();
        }
        [HttpGet("{id}")]
        public RacerDto GetById(int id)
        {
            return _racerService.GetById(id);
        }
        [HttpPost]
        public RacerGetDto Create(RacerGetDto racerGetdto) 
        {
            return _racerService.Create(racerGetdto);
        }
        [HttpDelete]
        public void Delete(int id) 
        {
            _racerService.Delete(id);
        }
        [HttpPut]
        public void Update(int id, RacerGetDto racerGetDto)
        {
            _racerService.Update(id, racerGetDto);
        }
    }
}
