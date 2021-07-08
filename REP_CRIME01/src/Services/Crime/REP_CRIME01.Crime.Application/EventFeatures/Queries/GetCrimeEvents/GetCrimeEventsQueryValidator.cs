using FluentValidation;
using REP_CRIME01.Crime.Common.Models;

namespace REP_CRIME01.Crime.Application.EventFeatures.Queries
{
    public static partial class GetCrimeEvents
    {
        public class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(x => x.CrimeEventsQueryString.SearchPhrase)
                    .MinimumLength(3)
                    .When(s => !string.IsNullOrEmpty(s.CrimeEventsQueryString.SearchPhrase));
                RuleFor(x => x.CrimeEventsQueryString.OrderBy.ToLower())
                    .IsEnumName(typeof(CrimeEventsOrder), false)
                    .When(s => !string.IsNullOrEmpty(s.CrimeEventsQueryString.OrderBy));
                RuleFor(x => x.CrimeEventsQueryString.PageIndex)
                    .GreaterThanOrEqualTo(1)
                    .Unless(x => x is null);
                RuleFor(x => x.CrimeEventsQueryString.PageSize)
                    .GreaterThanOrEqualTo(10)
                    .Unless(x => x is null);
            }
        }
    }

}