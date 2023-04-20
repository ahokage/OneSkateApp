﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneSkate.Web.Data;
using OneSkate.Web.Dtos;
using OneSkate.Web.Interfaces;
using OneSkate.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace OneSkate.Web.Services
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

                throw new Exception("Race not found.");

            _context.Races.Remove(raceInDb);
            _context.SaveChanges();

        }

        public IEnumerable<RaceGetDto> GetAll()
        {
            return _context.Races
                .Include(x => x.Racers)
                .ThenInclude(x => x.Racer)
                .Include(r => r.Results)
                .Select(_mapper.Map<Race, RaceGetDto>)
                .ToList();
        }

        public RaceGetDto GetById(int id)
        {
            var race = _context.Races
                .Include(x => x.Racers)
                .ThenInclude(x => x.Racer)
                .Include(x => x.Results)
                .FirstOrDefault(r => r.Id == id);

            if (race == null)
                throw new Exception("Race not found.");

            return _mapper.Map<RaceGetDto>(race);
        }
        public void Update(int id, RaceDto raceDto)
        {
            var raceInDb = _context.Races.Include(x => x.Racers).Include(x => x.Results).FirstOrDefault(x => x.Id == id);

            if (raceInDb == null)
                throw new Exception("Race not found.");

            _mapper.Map(raceDto, raceInDb);
            _context.SaveChanges();
        }
    }
}
