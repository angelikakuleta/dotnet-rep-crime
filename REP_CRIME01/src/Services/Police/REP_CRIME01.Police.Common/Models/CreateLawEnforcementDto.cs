namespace REP_CRIME01.Police.Common.Models
{
    public record CreateLawEnforcementDto
    {
        public string Code { get; init; }
        public string Rank { get; init; }
        public string PoliceDepartmentCode { get; init; }
        public string City { get; init; }
    }
}
