using FluentValidation;
using REP_CRIME01.Police.Domain.Entities;

namespace REP_CRIME01.Police.Application.LawEnforcementFeatures.Commands
{
    public static partial class CreateLawEnforcement
    {
        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.CreateLawEnforcementDto.Code).NotEmpty().Length(6);
                RuleFor(x => x.CreateLawEnforcementDto.City).NotEmpty();
                RuleFor(x => x.CreateLawEnforcementDto.Rank).NotEmpty().IsEnumName(typeof(LawEnforcementRank));
                RuleFor(x => x.CreateLawEnforcementDto.PoliceDepartmentCode).NotEmpty().Length(6);
            }
        }
    }    
}
