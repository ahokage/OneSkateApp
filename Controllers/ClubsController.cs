using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneSkate.Dtos;
using OneSkate.Interfaces;
using System.Collections;
using System.Collections.Generic;

namespace OneSkate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubsController : ControllerBase
    {
        private readonly IClubService _clubService;
        public ClubsController(IClubService clubService) 
        {
            _clubService = clubService;
        }
        [HttpGet]
        public IEnumerable<ClubDto> GetClubs()
        {
            return _clubService.GetAll();
        }

        [HttpGet("{id}")]
        public ClubDto GetClubById(int id)
        {
            return _clubService.GetById(id);
        }
        [HttpPost]
        public ClubDto CreateClub(ClubDto clubDto)
        {
            return _clubService.Create(clubDto);
        }
        [HttpPut]
        public void Update(int id, ClubDto clubDto)
        {
            _clubService.Update(id, clubDto);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            _clubService.Delete(id);
        }
    }
}
