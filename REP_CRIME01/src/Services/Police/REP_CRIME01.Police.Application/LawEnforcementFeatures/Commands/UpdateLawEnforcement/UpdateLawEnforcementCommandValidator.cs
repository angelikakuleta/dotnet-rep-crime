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
                RuleFor(x => x.Id).NotEmpty();
                RuleFor(x => x.UpdateLawEnforcementDto.City).NotEmpty();
                RuleFor(x => x.UpdateLawEnforcementDto.Rank).NotEmpty().IsEnumName(typeof(LawEnforcementRank));
                RuleFor(x => x.UpdateLawEnforcementDto.PoliceDepartmentCode).NotEmpty().Length(6);
            }
        }
    }    
}
