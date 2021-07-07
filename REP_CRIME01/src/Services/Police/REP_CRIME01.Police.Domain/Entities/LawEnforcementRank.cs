using System.ComponentModel;

namespace REP_CRIME01.Police.Domain.Entities
{
    public enum LawEnforcementRank
    {
        Officer = 0,
        Detective,
        Sergeant,
        Lieutenant,
        Capitan,
        Commander,
        [Description("Deputy Chief")]
        DeputyChief,
        Chief
    }
}
