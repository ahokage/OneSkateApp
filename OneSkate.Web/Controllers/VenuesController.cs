using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneSkate.Web.Dtos;
using OneSkate.Web.Interfaces;
using System.Collections.Generic;

namespace OneSkate.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenuesController : ControllerBase
    {
        private readonly IVenueService _venueService;
        public VenuesController(IVenueService venueService)
        {
            _venueService = venueService;
        }
        [HttpGet]
        public IEnumerable<VenueDto> GetAll()
        {
            return _venueService.GetAll();
        }
        [HttpGet("{id}")]
        public VenueDto GetById(int id)
        {
            return _venueService.GetById(id);
        }
        [HttpPost]
        public VenueDto Create(VenueDto venueDto)
        {
            return _venueService.Create(venueDto);
        }
        [HttpPut]
        public void Update (int id,VenueDto venueDto)
        {
            _venueService.Update(id, venueDto);
        }
        [HttpDelete]
        public void Delete (int id)
        {
            _venueService.Delete(id);
        }
    }
}
