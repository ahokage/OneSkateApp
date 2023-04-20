using AutoMapper;
using OneSkate.Web.Data;
using OneSkate.Web.Dtos;
using OneSkate.Web.Interfaces;
using OneSkate.Web.Models;

namespace OneSkate.Web.Services
{
    public class ClubService : IClubService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ClubService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ClubDto Create(ClubDto clubDto)
        {
            var club = _mapper.Map<Club>(clubDto);
            _context.Add(club);
            _context.SaveChanges();
            clubDto.Id = club.Id;

            return clubDto;
        }

        public void Delete(int id)
        {
            var clubInDb = _context.Clubs.FirstOrDefault(c => c.Id == id);

            if (clubInDb == null)
            {
                throw new Exception("Club not found.");
            }

            _context.Clubs.Remove(clubInDb);
            _context.SaveChanges();
        }

        public ClubDto GetById(int id)
        {
            var club = _context.Clubs.FirstOrDefault(cl => cl.Id == id);

            if (club == null)
                throw new Exception("Club not found");

            return _mapper.Map<ClubDto>(club);
        }

        public IEnumerable<ClubDto> GetAll()
        {
            return _context.Clubs.Select(_mapper.Map<Club, ClubDto>).ToList();
        }

        public void Update(int id, ClubDto clubDto)
        {
            var clubInDb = _context.Clubs.FirstOrDefault(_c => _c.Id == id);

            if (clubInDb == null)
                throw new Exception("Club not found.");

            _mapper.Map(clubDto, clubInDb);
            _context.SaveChanges();
        }
    }
}
