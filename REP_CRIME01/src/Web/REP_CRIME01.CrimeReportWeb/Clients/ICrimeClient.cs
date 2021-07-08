using REP_CRIME01.Crime.Common.Models;
using System;
using System.Threading.Tasks;

namespace REP_CRIME01.CrimeReportWeb
{
    public interface ICrimeClient
    {
        Task<Guid?> ReportCrimeEvent(CreateCrimeEventDto dto);
    }
}
