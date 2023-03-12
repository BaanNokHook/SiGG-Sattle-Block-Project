using Shopping.Aggregator.Extensions;
using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services
{
    public class SatelliteOrchestratorControllerService : ISatelliteOrchestratorControllerService
    {
        private readonly HttpClient _client;

        public SatelliteOrchestratorControllerService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<SatelliteOrchestratorControllerResponseModel>> GetSatelliteOrchestratorControllersByUserName(string userName)
        {
            var response = await _client.GetAsync($"/api/v1/SatelliteOrchestratorController/{userName}");
            return await response.ReadContentAs<List<SatelliteOrchestratorControllerResponseModel>>();
        }
    }
}