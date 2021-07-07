using AutoMapper;
using REP_CRIME01.Police.Application.CaseFeatures.Commands;
using REP_CRIME01.Police.Application.Models;
using REP_CRIME01.Police.Domain.Entities;

namespace REP_CRIME01.Police.Application.Profiles
{
    public class CaseProfile : Profile
    {
        public CaseProfile()
        {
            CreateMap<CreateCase.Command, Case>();
            CreateMap<UpdateCase.Command, Case>();
            CreateMap<Case, CaseVM>();
        }
    }
}
