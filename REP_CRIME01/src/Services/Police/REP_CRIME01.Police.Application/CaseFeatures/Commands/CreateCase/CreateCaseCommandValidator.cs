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
                RuleFor(x => x.CrimeReportId).NotEmpty();
                RuleFor(x => x.CrimeDate).NotEmpty().LessThan(DateTime.Now);
                RuleFor(x => x.DateReported).NotEmpty().LessThan(DateTime.Now);
                RuleFor(x => x.LawEnforcementCode).NotEmpty().Length(6);
                RuleFor(x => x.Description).NotEmpty();
            }
        }
    }    
}
