using AutoMapper;
using REP_CRIME01.Crime.Application.Commands;
using REP_CRIME01.Crime.Domain.Entities;
using REP_CRIME01.Crime.Domain.ValueObjects;

namespace REP_CRIME01.Crime.Application.Profiles
{
    public class CrimeEventProfile : Profile
    {
        public CrimeEventProfile()
        {
            CreateMap<CreateCrimeEvent.Command, CrimeEvent>()
                .ForMember(d => d.EventPlace, o => o.MapFrom(x => new EventPlace(x.City, x.Street)));
        }
    }
}
