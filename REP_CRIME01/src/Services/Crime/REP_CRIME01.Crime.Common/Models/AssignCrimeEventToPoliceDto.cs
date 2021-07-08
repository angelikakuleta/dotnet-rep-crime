namespace REP_CRIME01.Crime.Common.Models
{
    public record AssignCrimeEventToPoliceDto
    {
        public string Description { get; init; }
        public string LawEnforcementCode { get; init; }
    }
}
