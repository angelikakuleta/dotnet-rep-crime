using REP_CRIME01.Police.Domain.Common;
using System;

namespace REP_CRIME01.Police.Domain.Entities
{
    public class Case : AuditableEntity
    {       
        public Guid CrimeReportId { get; set; }
        public DateTime DateReported { get; set; }
        public DateTime CrimeDate { get; set; }
        public string Description { get; set; }
        public LawEnforcement LawEnforcement { get; set; }
    }
}
