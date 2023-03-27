using AutoMapper;
using OneSkate.Data;
using OneSkate.Dtos;
using OneSkate.Interfaces;
using OneSkate.Models;
using System.Collections.Generic;
using System.Linq;

namespace OneSkate.Services
{
    public class VenueService : IVenueService
    {
        private readonly ApplicationDbContext _context;

        private readonly IMapper _mapper;
        public VenueService(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public VenueDto Create(VenueDto venueDto)
        {
            var venue = _mapper.Map<Venue>(venueDto);
            _context.Venues.Add(venue);
            _context.SaveChanges();

            venueDto.Id = venueDto.Id;

            return venueDto;
        }

        public void Delete(int id)
        {
            var venueInDb = _context.Venues.FirstOrDefault(x => x.Id == id);
            if (venueInDb == null)
            {

            }
            else
            {
                _context.Venues.Remove(venueInDb);
                _context.SaveChanges();
            }
        }

        public IEnumerable<VenueDto> GetAll()
        {
            return _context.Venues.Select(_mapper.Map<Venue , VenueDto>).ToList();
        }

        public VenueDto GetById(int id)
        {
            var venue = _context.Venues.FirstOrDefault(c => c.Id == id);

            return _mapper.Map<VenueDto>(venue);
        }

        public void Update(int id, VenueDto venueDto)
        {
            var venueInDb = _context.Venues.FirstOrDefault(x => x.Id == id);
            if (venueInDb == null)
            {

            }
            else
            {
                _mapper.Map(venueDto, venueInDb);
                _context.SaveChanges();
            }

        }
    }
}
