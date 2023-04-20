using OneSkate.Dtos;
using System.Collections;
using System.Collections.Generic;

namespace OneSkate.Interfaces
{
    public interface IResultService
    {
        IEnumerable <ResultGetDto> GetAll();
        RaceGetDto RaceById(int id);
        RacerGetResultsDto RacerById(int id);
    }
}
