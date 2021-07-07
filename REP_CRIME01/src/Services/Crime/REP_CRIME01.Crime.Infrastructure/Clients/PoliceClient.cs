using REP_CRIME01.Police.Common.DTOs;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace REP_CRIME01.Crime.Infrastructure.Clients
{
    public class PoliceClient : IPoliceClient
    {
        private readonly HttpClient _httpClient;
        public PoliceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Guid?> CreateCase(CreateCaseDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/cases", dto);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Guid>();
            }

            return null;
        }
    }
}
