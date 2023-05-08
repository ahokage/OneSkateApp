using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using OneSkate.Web.Data;
using OneSkate.Web.Dtos;
using OneSkate.Web.Interfaces;
using OneSkate.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace OneSkate.Web.Services
{
    public class ResultService : IResultService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ResultService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<ResultGetDto> GetAll()
        {
            return _context.Results
            .Include(x => x.Race)
            .Include(x => x.Racer)
            .Select(_mapper.Map<Result, ResultGetDto>).ToList();
        }
        public IEnumerable<ResultRacerGetDto> GetAllRaces()
        {
            return _context.Results
                .Include(x => x.Race)
                .Include(x => x.Racer)
                .Select(_mapper.Map<Result, ResultRacerGetDto>).ToList();
        }
        public ResultDto GetRaceById(int id)
        {
            var race = _context.Results.FirstOrDefault(x => x.RaceId == id);

            if(race == null)
                throw new Exception("Results not found.");

            return _mapper.Map<Result, ResultDto>(race);
        }

        public ResultDto GetRacerById(int id)
        {
             var racer = _context.Results.FirstOrDefault(r => r.RacerId == id);

            if (racer == null)
                throw new Exception("Results not found.");

            return _mapper.Map<Result, ResultDto>(racer);
        }

        public RaceGetDto RaceById(int id)
        {
            var resultInDb = _context.Races
                .Include(x => x.Results)
                .ThenInclude(x => x.Racer)
                .FirstOrDefault(x => x.Id == id);

            if (resultInDb == null)
                throw new Exception("Results not found.");

            return _mapper.Map<RaceGetDto>(resultInDb);
        }
        public RacerGetResultsDto RacerById(int id)
        {
            var  racerInDb = _context.Racers
                .Include( x => x.Results)
                .ThenInclude( x => x.Race)
                .FirstOrDefault(x => x.Id==id);

            if (racerInDb == null)
                throw new Exception("Results not found.");

            return _mapper.Map<RacerGetResultsDto>(racerInDb);
        }
    }
}
