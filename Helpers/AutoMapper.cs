using AutoMapper;
using Microsoft.OpenApi.Writers;
using OneSkate.Dtos;
using OneSkate.Models;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

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
                CreateMap<RaceGetDto, Race>().ForMember(c => c.Id, opt => opt.Ignore());
                CreateMap<Race, RaceDto>();
                CreateMap<RaceDto, Race>().ForMember(c => c.Id, opt => opt.Ignore());
                CreateMap<Racer, RacerDto>();
                CreateMap<RacerDto, Racer>().ForMember(c => c.Id, opt => opt.Ignore());
                CreateMap<Result, ResultDto>();
                CreateMap<ResultDto, Result>();
                CreateMap<Result, ResultGetDto>().ForMember(c => c.RacerName , opt => opt.MapFrom(src => src.Racer.Name));
                CreateMap<ResultGetDto, Result>();

                CreateMap<Result, ResultRacerGetDto>().ForMember(c => c.RaceName , opt => opt.MapFrom(src => src.Race.Name));

                CreateMap<Venue, VenueDto>();
                CreateMap<VenueDto, Venue>().ForMember(c => c.Id, opt => opt.Ignore());

                CreateMap<RacerRace, RacerRaceDto>();
                CreateMap<RacerRaceDto, RacerRace>();


                CreateMap<Race, RaceGetDto>().ForMember(dest => dest.Racers, opt => opt.MapFrom(src => src.Racers.Select(x => x.Racer)));

                CreateMap<RaceDto, Race>().ForMember(dest => dest.Racers, opt => opt.MapFrom(src => src.Racers.Select(x => new RacerRace
                {
                    RacerId = x.Id,
                    RaceId = src.Id
                })))
                    .ForMember(c => c.Id, opt => opt.Ignore());

                CreateMap<RacerGetResultsDto, Racer>();

            }
        }
    }
}
