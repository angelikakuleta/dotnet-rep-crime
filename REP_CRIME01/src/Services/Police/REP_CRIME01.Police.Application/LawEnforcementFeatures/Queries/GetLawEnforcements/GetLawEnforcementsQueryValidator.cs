using FluentValidation;
using REP_CRIME01.Police.Application.Models;

namespace REP_CRIME01.Police.Application.LawEnforcementFeatures.Queries
{
    public static partial class GetLawEnforcements
    {
        public class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(x => x.SearchPhrase).MinimumLength(3).When(s => !string.IsNullOrEmpty(s.SearchPhrase));
                RuleFor(x => x.OrderBy.ToLower()).IsEnumName(typeof(LawEnforcementsOrder), false).When(s => !string.IsNullOrEmpty(s.OrderBy));
                RuleFor(x => x.PageIndex).GreaterThanOrEqualTo(1).Unless(x => x is null);
                RuleFor(x => x.PageSize).GreaterThanOrEqualTo(10).Unless(x => x is null);
            }
        }
    }

}