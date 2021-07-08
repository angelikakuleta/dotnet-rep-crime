using System;

namespace REP_CRIME01.Police.Common.Models
{
    public record UpdateCaseDto
    {
        public DateTime CrimeDate { get; init; }
        public string Description { get; init; }
        public string LawEnforcementCode { get; init; }
    }
}
