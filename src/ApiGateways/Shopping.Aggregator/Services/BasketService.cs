using Shopping.Aggregator.Extensions;
using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services
{
    public class SatelliteOrchestratorService : ISatelliteOrchestratorService
    {
        private readonly HttpClient _client;

        public SatelliteOrchestratorService(HttpClient client)
        {
            _client = client;
        }

        public async Task<SatelliteOrchestratorModel> GetSatelliteOrchestrator(string userName)
        {
            var response = await _client.GetAsync($"/api/v1/SatelliteOrchestrator/{userName}");
            return await response.ReadContentAs<SatelliteOrchestratorModel>();
        }
    }
}