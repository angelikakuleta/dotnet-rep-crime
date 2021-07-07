using AutoMapper;
using REP_CRIME01.Police.Application.LawEnforcementFeatures.Commands;
using REP_CRIME01.Police.Application.Models;
using REP_CRIME01.Police.Domain.Entities;

namespace REP_CRIME01.Police.Application.Profiles
{
    public class LawEnforcementProfile : Profile
    {
        public LawEnforcementProfile()
        {
            CreateMap<CreateLawEnforcement.Command, LawEnforcement>();
            CreateMap<UpdateLawEnforcement.Command, LawEnforcement>();
            CreateMap<LawEnforcement, LawEnforcementVM>();
        }       
    }
}
