using System;

namespace REP_CRIME01.Crime.Common.Models
{
    public record CrimeEventVM
    {
        public Guid Id { get; init; }
        public DateTime EventDate { get; init; }
        public string EventType { get; init; }
        public string Description { get; init; }
        public EventPlaceDto EventPlace { get; init; }
        public string Status { get; init; }
        public string LawEnforcementCode { get; init; }
    }
}
