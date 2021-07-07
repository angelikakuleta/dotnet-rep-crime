using FluentValidation;
using REP_CRIME01.Police.Domain.Entities;
using System;

namespace REP_CRIME01.Police.Application.CaseFeatures.Commands
{
    public static partial class CreateCase
    {
        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.CreateCaseDto.CrimeReportId).NotEmpty();
                RuleFor(x => x.CreateCaseDto.CrimeDate).NotEmpty().LessThan(DateTime.Now);
                RuleFor(x => x.CreateCaseDto.DateReported).NotEmpty().LessThan(DateTime.Now);
                RuleFor(x => x.CreateCaseDto.LawEnforcementCode).NotEmpty().Length(6);
                RuleFor(x => x.CreateCaseDto.Description).NotEmpty();
            }
        }
    }    
}
