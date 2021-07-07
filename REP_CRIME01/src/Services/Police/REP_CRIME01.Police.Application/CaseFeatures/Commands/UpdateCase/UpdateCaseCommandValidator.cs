using FluentValidation;
using REP_CRIME01.Police.Domain.Entities;
using System;

namespace REP_CRIME01.Police.Application.CaseFeatures.Commands
{
    public static partial class UpdateCase
    {
        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.Id).NotEmpty();
                RuleFor(x => x.CrimeDate).NotEmpty().LessThan(DateTime.Now);
                RuleFor(x => x.Description).NotEmpty();
                RuleFor(x => x.LawEnforcementCode).NotEmpty().Length(6);
            }
        }
    }    
}
