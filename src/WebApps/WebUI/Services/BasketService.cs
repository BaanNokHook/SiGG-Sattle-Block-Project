using WebUI.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using WebUI.Extensions;

namespace WebUI.Services
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
            var response = await _client.GetAsync($"/SatelliteOrchestrator/{userName}");
            return await response.ReadContentAs<SatelliteOrchestratorModel>();
        }

        public async Task<SatelliteOrchestratorModel> UpdateSatelliteOrchestrator(SatelliteOrchestratorModel model)
        {
            var response = await _client.PostAsJson($"/SatelliteOrchestrator", model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<SatelliteOrchestratorModel>();
            else
            {
                throw new Exception("Something went wrong when calling api.");
            }
        }

        public async Task CheckoutSatelliteOrchestrator(SatelliteOrchestratorCheckoutModel model)
        {
            var response = await _client.PostAsJson($"/SatelliteOrchestrator/Checkout", model);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Something went wrong when calling api.");
            }
        }
    }
}
