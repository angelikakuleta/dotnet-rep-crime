using System;

namespace REP_CRIME01.Police.Application.Models
{
    public record LawEnforcementVM
    {
        public Guid Id { get; init; }
        public string Code { get; init; }
        public string Rank { get; init; }
        public string PoliceDepartmentCode { get; init; }
        public string City { get; init; }
    }
}
