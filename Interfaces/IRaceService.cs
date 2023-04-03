using OneSkate.Dtos;
using System.Collections;
using System.Collections.Generic;

namespace OneSkate.Interfaces
{
    public interface IRaceService
    {
        IEnumerable<RaceGetDto> GetAll();
        RaceDto GetById(int id);
        RaceDto Create(RaceDto raceDto);
        void Delete(int id);
        void Update(int id,RaceDto raceDto);
    }
}
