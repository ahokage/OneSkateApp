using AutoMapper;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using OneSkate.Data;
using OneSkate.Dtos;
using OneSkate.Interfaces;
using OneSkate.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace OneSkate.Services
{
    public class ClubService : IClubService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ClubService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ClubDto Create(ClubDto clubDto)
        {
            var club = _mapper.Map<Club>(clubDto);
            _context.Add(club);
            _context.SaveChanges();
            clubDto.Id = club.Id;

            return clubDto;
        }

        public void Delete(int id)
        {
            var clubInDb = _context.Clubs.FirstOrDefault(c => c.Id == id);

            if (clubInDb == null)
            {
                throw new Exception("Nuk ekziston klub me ate ID.");
            }

            _context.Clubs.Remove(clubInDb);
            _context.SaveChanges();
        }

        public ClubDto GetById(int id)
        {
            var club = _context.Clubs.FirstOrDefault(cl => cl.Id == id);

            if (club == null)
                throw new Exception("Nuk ka klub me ID: " + id);

            return _mapper.Map<ClubDto>(club);
        }

        public IEnumerable<ClubDto> GetAll()
        {
            return _context.Clubs.Select(_mapper.Map<Club, ClubDto>).ToList();
        }

        public void Update(int id, ClubDto clubDto)
        {
            var clubInDb = _context.Clubs.FirstOrDefault(_c => _c.Id == id);
            if (clubInDb == null)
                throw new Exception("Klubi me ID: " + id + " nuk ekziston");

            _mapper.Map(clubDto, clubInDb);
            _context.SaveChanges();
        }
    }
}
