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
                RuleFor(x => x.CreateCrimeEventDto.EventDate).NotEmpty().LessThan(DateTime.Now);
                RuleFor(x => x.CreateCrimeEventDto.EventType).NotEmpty().IsEnumName(typeof(EventType));
                RuleFor(x => x.CreateCrimeEventDto.Description).NotEmpty();
                RuleFor(x => x.CreateCrimeEventDto.City).NotEmpty();
                RuleFor(x => x.CreateCrimeEventDto.Street).NotEmpty();
                RuleFor(x => x.CreateCrimeEventDto.ReportingPersonEmail).NotEmpty().EmailAddress();
            }
        }
    }    
}
