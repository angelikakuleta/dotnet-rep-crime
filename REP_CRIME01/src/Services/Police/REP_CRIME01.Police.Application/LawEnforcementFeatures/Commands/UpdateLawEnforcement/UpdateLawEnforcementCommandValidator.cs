using FluentValidation;
using REP_CRIME01.Police.Domain.Entities;

namespace REP_CRIME01.Police.Application.LawEnforcementFeatures.Commands
{
    public static partial class UpdateLawEnforcement
    {
        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.City).NotEmpty();
                RuleFor(x => x.Rank).NotEmpty().IsEnumName(typeof(LawEnforcementRank));
                RuleFor(x => x.PoliceDepartmentCode).NotEmpty().Length(6);
            }
        }
    }    
}
