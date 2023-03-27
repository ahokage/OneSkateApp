using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneSkate.Dtos;
using OneSkate.Interfaces;
using System.Collections.Generic;

namespace OneSkate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultsController : ControllerBase
    {
        private readonly IResultService _resultService;
        public ResultsController(IResultService resultService)
        { 
            _resultService = resultService;
        }
        [HttpGet]
        public IEnumerable<ResultGetDto> GetAll()
        {
            return _resultService.GetAll();
        }
        [HttpGet("{id}")]
        public ResultGetDto GetById(int id)
        {
            return _resultService.GetById(id);
        }
        [HttpPost]
        public ResultDto Create(ResultDto resultDto)
        {
            return _resultService.Create(resultDto);
        }
        [HttpPut]
        public void Update(int id, ResultDto resultDto) 
        {
            _resultService.Update(id, resultDto);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            _resultService.Delete(id);
        }
    }
}
