using AutoMapper;
using REP_CRIME01.Police.Common.Models;
using REP_CRIME01.Police.Domain.Entities;

namespace REP_CRIME01.Police.Application.Profiles
{
    public class CaseProfile : Profile
    {
        public CaseProfile()
        {
            CreateMap<CreateCaseDto, Case>();
            CreateMap<UpdateCaseDto, Case>();
            CreateMap<Case, CaseVM>();
        }
    }
}
