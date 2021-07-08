using System;

namespace REP_CRIME01.Crime.Common.Models
{
    public record UpdateCrimeEventDto
    {
        public DateTime EventDate { get; init; }
        public string EventType { get; init; }
        public string Description { get; init; }
        public string City { get; init; }
        public string Street { get; init; }
        public string ReportingPersonEmail { get; init; }
    }
}
