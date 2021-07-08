using System;

namespace REP_CRIME01.Police.Common.Models
{
    public record CreateCaseDto
    {
        public Guid CrimeReportId { get; init; }
        public DateTime DateReported { get; init; }
        public DateTime CrimeDate { get; init; }
        public string Description { get; init; }
        public string LawEnforcementCode { get; init; }
    }
}
