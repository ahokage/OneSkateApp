using OneSkate.Dtos;
using System.Collections;
using System.Collections.Generic;

namespace OneSkate.Interfaces
{
    public interface IResultService
    {
        IEnumerable <ResultGetDto> GetAll();
        ResultGetDto GetById(int id);
        ResultDto Create(ResultDto resultDto);
        void Delete(int id);
        void Update(int id,ResultDto resultDto);
    }
}
