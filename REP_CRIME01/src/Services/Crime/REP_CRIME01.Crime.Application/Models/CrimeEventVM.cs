using REP_CRIME01.Crime.Domain.ValueObjects;
using System;

namespace REP_CRIME01.Crime.Application.Models
{
    public record CrimeEventVM
    {
        public Guid Id { get; init; }
        public DateTime EventDate { get; init; }
        public string EventType { get; init; }
        public string Description { get; init; }
        public EventPlace EventPlace { get; init; }
        public string Status { get; init; }
    }
}
