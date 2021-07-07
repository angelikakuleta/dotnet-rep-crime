using System;

namespace REP_CRIME01.Police.Common.DTOs
{
    public record UpdateCaseDto
    {
        public Guid Id { get; set; }
        public DateTime CrimeDate { get; init; }
        public string Description { get; init; }
        public string LawEnforcementCode { get; init; }
    }
}
