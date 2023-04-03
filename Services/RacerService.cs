using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OneSkate.Data;
using OneSkate.Dtos;
using OneSkate.Interfaces;
using OneSkate.Models;
using System;
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
        public RacerDto Create(RacerDto racerGetDto)
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
                throw new Exception("Racer not found.");

            _context.Racers.Remove(racerInDb);
            _context.SaveChanges();
            
        }

        public IEnumerable<RacerGetDto> GetAll()
        {
            return _context.Racers.Include(x => x.Club).Select(_mapper.Map<Racer, RacerGetDto>).ToList();
        }

        public RacerDto GetById(int id)
        {
            var racer = _context.Racers.Include(x => x.Club).Include(x => x.Club).FirstOrDefault(ra => ra.Id == id);

            if (racer == null)
                throw new Exception("Racer not found.");

            return _mapper.Map<RacerDto>(racer);
        }
        //TODO Fix this
        public void Update(int id,RacerDto racerDto)
        {
            var racerInDb = _context.Racers.Include(x => x.Club).FirstOrDefault(x => x.Id == id);

            if (racerInDb == null)
                throw new Exception("Racer not found.");

            _mapper.Map(racerDto, racerInDb);
            _context.Update(racerInDb);
            _context.SaveChanges();
        }
    }
}
