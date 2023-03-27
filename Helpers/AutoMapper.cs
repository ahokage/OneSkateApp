using AutoMapper;
using OneSkate.Dtos;
using OneSkate.Models;

namespace OneSkate.Helpers
{
    public class AutoMapper
    {
        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<Club, ClubDto>();
                CreateMap<ClubDto, Club>().ForMember(c => c.Id, opt => opt.Ignore());
                CreateMap<Race, RaceDto>();
                CreateMap<RaceDto, Race>().ForMember(c => c.Id, opt => opt.Ignore());
                CreateMap<Racer, RacerDto>();
                CreateMap<RacerDto, Racer>().ForMember(c => c.Id, opt => opt.Ignore());
                CreateMap<Result, ResultDto>();
                CreateMap<ResultDto, Result>().ForMember(c => c.Id, opt => opt.Ignore());
                CreateMap<Result, ResultGetDto>().ForMember(c => c.RaceName , opt => opt.MapFrom(src => src.Race.Name))
                         .ForMember(c => c.RacerName , opt => opt.MapFrom(src => src.Racer.Name));
                CreateMap<ResultGetDto, Result>().ForMember(c => c.Id, opt => opt.Ignore());
                CreateMap<Venue, VenueDto>();
                CreateMap<VenueDto, Venue>().ForMember(c => c.Id, opt => opt.Ignore());
                CreateMap<RacerDto, RacerGetDto>();
                CreateMap<RacerGetDto, Racer>().ForMember(c => c.Id ,opt => opt.Ignore());

            }
        }
    }
}
