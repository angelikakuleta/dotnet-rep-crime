using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace REP_CRIME01.Crime.Common
{
    public enum EventType
    {
        Burglary,
        Assault,
        Arson,
        [Display(Name = "Domestic Abuse")]
        DomesticAbuse,
        Rape,
        Murder
    }
}
