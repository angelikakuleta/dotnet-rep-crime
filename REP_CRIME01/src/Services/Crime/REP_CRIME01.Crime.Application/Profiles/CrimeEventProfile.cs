using AutoMapper;
using REP_CRIME01.Crime.Common.Models;
using REP_CRIME01.Crime.Domain.Entities;
using REP_CRIME01.Crime.Domain.ValueObjects;
using REP_CRIME01.EventBus.Messages;

namespace REP_CRIME01.Crime.Application.Profiles
{
    public class CrimeEventProfile : Profile
    {
        public CrimeEventProfile()
        {
            CreateMap<CreateCrimeEventDto, CrimeEvent>()
                .ForMember(d => d.EventPlace, o => o.MapFrom(x => new EventPlace(x.City, x.Street)));
            CreateMap<UpdateCrimeEventDto, CrimeEvent>()
                .ForMember(d => d.EventPlace, o => o.MapFrom(x => new EventPlace(x.City, x.Street)));
            CreateMap<EventPlace, EventPlaceDto>();
            CreateMap<CrimeEvent, CrimeEventVM>(); 
            CreateMap<CrimeEvent, CrimeEventAssignedNotification>();
        }
    }
}
