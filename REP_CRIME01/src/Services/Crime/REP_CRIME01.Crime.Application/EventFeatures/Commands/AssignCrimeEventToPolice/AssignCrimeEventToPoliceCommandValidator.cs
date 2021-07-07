﻿using FluentValidation;
using REP_CRIME01.Crime.Domain.Entities;
using System;

namespace REP_CRIME01.Crime.Application.EventFeatures.Commands
{
    public static partial class AssignCrimeEventToPolice
    {
        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.Id).NotEmpty();
                RuleFor(x => x.Description).NotEmpty();
                RuleFor(x => x.LawEnforcementCode).NotEmpty().Length(6);
            }
        }
    }    
}
