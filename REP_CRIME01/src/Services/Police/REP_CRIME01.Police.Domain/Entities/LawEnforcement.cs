using REP_CRIME01.Police.Domain.Common;
using System.Collections.Generic;

namespace REP_CRIME01.Police.Domain.Entities
{
    public class LawEnforcement : AuditableEntity
    {
        public string Code { get; set; }
        public LawEnforcementRank Rank { get; set; }
        public string PoliceDepartmentCode { get; set; }
        public string City { get; set; }
        public IEnumerable<Case> Cases { get; set; }
    }
}
