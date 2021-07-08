using System;

namespace REP_CRIME01.Police.Common.Models
{
    public record CaseVM
    {
        public Guid Id { get; set; }
        public Guid CrimeReportId { get; set; }
        public DateTime DateReported { get; set; }
        public DateTime CrimeDate { get; set; }
        public string Description { get; set; }
        public LawEnforcementVM LawEnforcement { get; set; }
    }
}
