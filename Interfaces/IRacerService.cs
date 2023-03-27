using OneSkate.Dtos;
using System.Collections.Generic;
using System.Collections;

namespace OneSkate.Interfaces
{
    public interface IRacerService
    {
        IEnumerable<RacerGetDto> GetAll();
        RacerDto GetById(int id);
        RacerGetDto Create(RacerGetDto racerGetDto);
        void Delete(int id);
        void Update(int id,RacerGetDto racerGetDto);
    }
}
