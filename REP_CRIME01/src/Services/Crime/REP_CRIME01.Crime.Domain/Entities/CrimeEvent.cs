using REP_CRIME01.Crime.Common;
using REP_CRIME01.Crime.Domain.Common;
using REP_CRIME01.Crime.Domain.ValueObjects;
using System;
using System.ComponentModel.DataAnnotations;

namespace REP_CRIME01.Crime.Domain.Entities
{
    public class CrimeEvent : AuditableEntity
    {
        public DateTime EventDate { get; set; }

        [EnumDataType(typeof(EventType))]
        public string EventType { get; set; }

        public string Description { get; set; }

        public EventPlace EventPlace { get; set; }

        public string ReportingPersonEmail { get; set; }

        [EnumDataType(typeof(EventStatus))]
        public string Status { get; set; } = EventStatus.Waiting.ToString();

        public string LawEnforcementCode { get; set; }

        public bool IsLawEnforcementAssigned => !string.IsNullOrEmpty(LawEnforcementCode);
    }
}
