using OneSkate.Web.Dtos;
using System.Collections;
using System.Collections.Generic;

namespace OneSkate.Web.Interfaces
{
    public interface IClubService
    {
        IEnumerable<ClubDto> GetAll();
        ClubDto GetById(int id);
        ClubDto Create(ClubDto clubDto);
        void Delete(int id);
        void Update(int id,ClubDto clubDto);
    }
}
