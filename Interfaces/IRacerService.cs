using OneSkate.Dtos;
using System.Collections.Generic;
using System.Collections;

namespace OneSkate.Interfaces
{
    public interface IRacerService
    {
        IEnumerable<RacerDto> GetAll();
        RacerDto GetById(int id);
        RacerDto Create(RacerDto racerGetDto);
        void Delete(int id);
        void Update(int id,RacerDto racerGetDto);
    }
}
