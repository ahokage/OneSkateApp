using OneSkate.Web.Dtos;
using System.Collections;
using System.Collections.Generic;

namespace OneSkate.Web.Interfaces
{
    public interface IRaceService
    {
        IEnumerable<RaceGetDto> GetAll();
        RaceGetDto GetById(int id);
        RaceDto Create(RaceDto raceDto);
        void Delete(int id);
        void Update(int id,RaceDto raceDto);
    }
}
