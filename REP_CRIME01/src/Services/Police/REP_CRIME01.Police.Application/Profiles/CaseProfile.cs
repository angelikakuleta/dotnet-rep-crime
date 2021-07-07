using AutoMapper;
using REP_CRIME01.Police.Application.CaseFeatures.Commands;
using REP_CRIME01.Police.Application.Models;
using REP_CRIME01.Police.Common.DTOs;
using REP_CRIME01.Police.Domain.Entities;

namespace REP_CRIME01.Police.Application.Profiles
{
    public class CaseProfile : Profile
    {
        public CaseProfile()
        {
            CreateMap<CreateCaseDto, Case >();
            CreateMap<UpdateCaseDto, Case>();
            CreateMap<Case, CaseVM>();
        }
    }
}
