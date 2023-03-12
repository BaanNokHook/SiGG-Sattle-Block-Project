using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using WebUI.Models;
using WebUI.Extensions;

namespace WebUI.Services
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
            var response = await _client.GetAsync("/DataSatellite");
            return await response.ReadContentAs<List<DataSatelliteModel>>();
        }

        public async Task<DataSatelliteModel> GetDataSatellite(string id)
        {
            var response = await _client.GetAsync($"/DataSatellite/{id}");
            return await response.ReadContentAs<DataSatelliteModel>();
        }

        public async Task<IEnumerable<DataSatelliteModel>> GetDataSatelliteByCategory(string category)
        {
            var response = await _client.GetAsync($"/DataSatellite/GetProductByCategory/{category}");
            return await response.ReadContentAs<List<DataSatelliteModel>>();
        }

        public async Task<DataSatelliteModel> CreateDataSatellite(DataSatelliteModel model)
        {
            var response = await _client.PostAsJson($"/DataSatellite", model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<DataSatelliteModel>();
            else
            {
                throw new Exception("Something went wrong when calling api.");
            }
        }
    }
}