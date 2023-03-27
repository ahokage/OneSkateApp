using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OneSkate.Data;
using OneSkate.Dtos;
using OneSkate.Interfaces;
using OneSkate.Models;
using System.Collections.Generic;
using System.Linq;

namespace OneSkate.Services
{
    public class RaceService : IRaceService
    {
        private readonly ApplicationDbContext _context;

        private readonly IMapper _mapper;
        public RaceService(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public RaceDto Create(RaceDto raceDto)
        {
            var race = _mapper.Map<Race>(raceDto);
            _context.Races.Add(race);
            _context.SaveChanges();
            raceDto.Id = race.Id;

            return raceDto;
        }

        public void Delete(int id)
        {
            var raceInDb = _context.Races.FirstOrDefault(r => r.Id == id);

            if (raceInDb == null)
            {

            }
            else
            {
                _context.Races.Remove(raceInDb);
                _context.SaveChanges();
            }
        }

        public IEnumerable<RaceDto> GetAll()
        {
            return _context.Races.Include(x => x.Racers).Include(x => x.Venue).Select(_mapper.Map<Race, RaceDto>).ToList();
        }

        public RaceDto GetById(int id)
        {
            var race = _context.Races.FirstOrDefault(r => r.Id == id);

            return _mapper.Map<RaceDto>(race);
        }
        public void Update(int id, RaceDto raceDto)
        {
            var raceInDb = _context.Races.FirstOrDefault(x => x.Id == id);

            if(raceInDb == null)
            {

            }
            else
            {
                _mapper.Map(raceDto, raceInDb);
                _context.SaveChanges();
            }
        }
    }
}
