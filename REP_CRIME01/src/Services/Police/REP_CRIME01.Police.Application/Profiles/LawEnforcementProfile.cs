using AutoMapper;
using REP_CRIME01.Police.Common.Models;
using REP_CRIME01.Police.Domain.Entities;

namespace REP_CRIME01.Police.Application.Profiles
{
    public class LawEnforcementProfile : Profile
    {
        public LawEnforcementProfile()
        {
            CreateMap<CreateLawEnforcementDto, LawEnforcement>();
            CreateMap<UpdateLawEnforcementDto, LawEnforcement>();
            CreateMap<LawEnforcement, LawEnforcementVM>();
        }       
    }
}
