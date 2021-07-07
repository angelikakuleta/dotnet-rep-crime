using FluentValidation;
using REP_CRIME01.Crime.Domain.Entities;
using System;

namespace REP_CRIME01.Crime.Application.EventFeatures.Commands
{
    public static partial class CreateCrimeEvent
    {
        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.EventDate).NotEmpty().LessThan(DateTime.Now);
                RuleFor(x => x.EventType).NotEmpty().IsEnumName(typeof(EventType));
                RuleFor(x => x.Description).NotEmpty();
                RuleFor(x => x.City).NotEmpty();
                RuleFor(x => x.Street).NotEmpty();
                RuleFor(x => x.ReportingPersonEmail).NotEmpty().EmailAddress();
            }
        }
    }    
}
