using AutoMapper;
using Microsoft.AspNetCore.Builder;
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
    public class ResultService : IResultService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ResultService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ResultDto Create(ResultDto resultDto)
        {
            var result = _mapper.Map<Result>(resultDto);
            _context.Results.Add(result);
            _context.SaveChanges();
            return resultDto;
        }

        public void Delete(int id)
        {
            var resultInDb = _context.Results.FirstOrDefault(x => x.Id == id);

            if (resultInDb == null)
                throw new Exception("Results not found.");

            _context.Results.Remove(resultInDb);
            _context.SaveChanges();

        }

        public IEnumerable<ResultGetDto> GetAll()
        {
            return _context.Results.Include(x => x.Race).Include(x => x.Racer).Select(_mapper.Map<Result, ResultGetDto>).ToList();
        }

        public ResultGetDto GetById(int id)
        {
            var resultInDb = _context.Results.FirstOrDefault(x => x.Id == id);

            if (resultInDb == null)
                throw new Exception("Results not found.");

            return _mapper.Map<ResultGetDto>(resultInDb);
        }

        public void Update(int id, ResultDto resultDto)
        {
            var resultInDb = _context.Results.FirstOrDefault(x => x.Id == id);

            if (resultInDb == null)
                throw new Exception("Results not found.");

            _mapper.Map(resultDto, resultInDb);
            _context.SaveChanges();
        }
    }
}
