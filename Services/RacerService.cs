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
    public class RacerService : IRacerService
    {
        private readonly ApplicationDbContext _context;

        private readonly IMapper _mapper;
        public RacerService(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public RacerGetDto Create(RacerGetDto racerGetDto)
        {
            var racer = _mapper.Map<Racer>(racerGetDto);
            _context.Racers.Add(racer);
            _context.SaveChanges();
            racerGetDto.Id = racer.Id;

            return racerGetDto;
        }

        public void Delete(int id)
        {
            var racerInDb = _context.Racers.FirstOrDefault(r => r.Id == id);

            if (racerInDb == null)
            {
            }
            else
            {
                _context.Racers.Remove(racerInDb);
                _context.SaveChanges();
            }
        }

        public IEnumerable<RacerGetDto> GetAll()
        {
            return _context.Racers.Include(x => x.Club).Include(x => x.Race).Select(_mapper.Map<Racer, RacerGetDto>).ToList();
        }

        public RacerDto GetById(int id)
        {
            var racer = _context.Racers.Include(x => x.Club).Include(x => x.Club).FirstOrDefault(ra => ra.Id == id);

            return _mapper.Map<RacerDto>(racer);
        }
        //TODO Fix this
        public void Update(int id,RacerGetDto racerGetDto)
        {
            var racerInDb = _context.Racers.Include(x => x.Race).Include(x => x.Club).FirstOrDefault(x => x.Id == id);

            if(racerInDb == null)
            {

            }
            else
            {
                _mapper.Map(racerGetDto, racerInDb);
                _context.Update(racerInDb);
                _context.SaveChanges();
            }
        }
    }
}
