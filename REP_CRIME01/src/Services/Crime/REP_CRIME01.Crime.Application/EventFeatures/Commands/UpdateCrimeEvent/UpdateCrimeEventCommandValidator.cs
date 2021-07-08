using FluentValidation;
using REP_CRIME01.Crime.Domain.Entities;
using System;

namespace REP_CRIME01.Crime.Application.EventFeatures.Commands
{
    public static partial class UpdateCrimeEvent
    {
        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.UpdateCrimeEventDto.EventDate).NotEmpty().LessThan(DateTime.Now);
                RuleFor(x => x.UpdateCrimeEventDto.EventType).NotEmpty().IsEnumName(typeof(EventType));
                RuleFor(x => x.UpdateCrimeEventDto.Description).NotEmpty();
                RuleFor(x => x.UpdateCrimeEventDto.City).NotEmpty();
                RuleFor(x => x.UpdateCrimeEventDto.Street).NotEmpty();
                RuleFor(x => x.UpdateCrimeEventDto.ReportingPersonEmail).NotEmpty().EmailAddress();
            }
        }
    }    
}
