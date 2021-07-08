using System;

namespace REP_CRIME01.Police.Common.Models
{
    public record UpdateLawEnforcementDto
    {
        public string Rank { get; init; }
        public string PoliceDepartmentCode { get; init; }
        public string City { get; init; }
    }
}
