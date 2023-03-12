using Shopping.Aggregator.Extensions;
using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services
{
    public class DataSatelliteService : IDataSatelliteService
    {
        private readonly HttpClient _client;

        public DataSatelliteService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<DataSatelliteModel>> GetDataSatellite()
        {
            var response = await _client.GetAsync("/api/v1/DataSatellite");
            return await response.ReadContentAs<List<DataSatelliteModel>>();
        }

        public async Task<DataSatelliteModel> GetDataSatellite(string id)
        {
            var response = await _client.GetAsync($"/api/v1/DataSatellite/{id}");
            return await response.ReadContentAs<DataSatelliteModel>();
        }

        public async Task<IEnumerable<DataSatelliteModel>> GetDataSatelliteByCategory(string category)
        {
            var response = await _client.GetAsync($"/api/v1/DataSatellite/GetProductByCategory/{category}");
            return await response.ReadContentAs<List<DataSatelliteModel>>();
        }
    }
}