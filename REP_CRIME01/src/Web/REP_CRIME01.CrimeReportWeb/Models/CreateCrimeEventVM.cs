using REP_CRIME01.Crime.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace REP_CRIME01.CrimeReportWeb.Models
{
    public record CreateCrimeEventVM
    {
        [Required]
        public DateTime EventDate { get; init; }

        [Required]
        public EventType EventType { get; init; }

        [Required]
        public string Description { get; init; }

        [Required, MinLength(3)]
        public string City { get; init; }

        [Required, MinLength(3)]
        public string Street { get; init; }

        [Required]
        [EmailAddress]
        public string ReportingPersonEmail { get; init; }
    }
}
