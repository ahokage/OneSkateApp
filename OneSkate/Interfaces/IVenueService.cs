using OneSkate.Dtos;
using System.Collections;
using System.Collections.Generic;

namespace OneSkate.Interfaces
{
    public interface IVenueService
    {
        IEnumerable<VenueDto> GetAll();
        VenueDto GetById(int id);
        VenueDto Create(VenueDto venueDto);
        void Update(int id,VenueDto venueDto);
        void Delete(int id);
    }
}
