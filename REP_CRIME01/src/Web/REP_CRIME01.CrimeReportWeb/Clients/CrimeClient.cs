using REP_CRIME01.Crime.Common.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace REP_CRIME01.CrimeReportWeb
{
    public class CrimeClient : ICrimeClient
    {

        private readonly HttpClient _httpClient;
        public CrimeClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Guid?> ReportCrimeEvent(CreateCrimeEventDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/events", dto);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Guid>();
            }

            return null;
        }
    }
}
