using OneSkate.Web.Dtos;
using System.Collections;
using System.Collections.Generic;

namespace OneSkate.Web.Interfaces
{
    public interface IResultService
    {
        IEnumerable <ResultGetDto> GetAll();
        IEnumerable<ResultRacerGetDto> GetAllRaces();
        RaceGetDto RaceById(int id);
        RacerGetResultsDto RacerById(int id);
        ResultDto GetRaceById(int id);
        ResultDto GetRacerById(int id);
    }
}
