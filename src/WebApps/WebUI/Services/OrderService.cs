using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using WebUI.Models;
using WebUI.Extensions;

namespace WebUI.Services
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
            var response = await _client.GetAsync($"/SatelliteOrchestratorController/{userName}");
            return await response.ReadContentAs<List<SatelliteOrchestratorControllerResponseModel>>();
        }
    }
}
