using FluentValidation;
using REP_CRIME01.Police.Application.Models;

namespace REP_CRIME01.Police.Application.CaseFeatures.Queries
{
    public static partial class GetCasesByLawEnforcementId
    {
        public class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(x => x.LawEnforcementId).NotEmpty();
                RuleFor(x => x.QueryString.SearchPhrase).MinimumLength(3).When(s => !string.IsNullOrEmpty(s.QueryString.SearchPhrase));
                RuleFor(x => x.QueryString.OrderBy.ToLower()).IsEnumName(typeof(CasesOrder), false).When(s => !string.IsNullOrEmpty(s.QueryString.OrderBy));
                RuleFor(x => x.QueryString.PageIndex).GreaterThanOrEqualTo(1).Unless(x => x is null);
                RuleFor(x => x.QueryString.PageSize).GreaterThanOrEqualTo(10).Unless(x => x is null);
            }
        }
    }

}