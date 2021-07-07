using FluentValidation;
using REP_CRIME01.Crime.Application.Models;

namespace REP_CRIME01.Crime.Application.Queries
{
    public static partial class GetCrimeEvents
    {
        public class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(x => x.SearchPhrase).MinimumLength(3).When(s => !string.IsNullOrEmpty(s.SearchPhrase));
                RuleFor(x => x.OrderBy.ToLower()).IsEnumName(typeof(CrimeEventsOrder), false).When(s => !string.IsNullOrEmpty(s.OrderBy));
                RuleFor(x => x.PageIndex).GreaterThanOrEqualTo(1).Unless(x => x is null);
                RuleFor(x => x.PageSize).GreaterThanOrEqualTo(10).LessThanOrEqualTo(100).Unless(x => x is null);
            }
        }
    }

}