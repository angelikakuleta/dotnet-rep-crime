using System;

namespace REP_CRIME01.EventBus.Messages
{
    public record CrimeEventAssignedNotification
    {
        public Guid Id { get; init; }
        public DateTime CreatedDate { get; set; }
        public string ReportingPersonEmail { get; init; }
        public string LawEnforcementCode { get; init; }
    }
}
