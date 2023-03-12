using SatelliteOrchestrator.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace SatelliteOrchestrator.API.Repositories
{
    public class SatelliteOrchestratorRepository : ISatelliteOrchestratorRepository
    {
        private readonly IDistributedCache _redisCache;

        public SatelliteOrchestratorRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }

        public async Task DeleteSatelliteOrchestrator(string userName)
        {
            await _redisCache.RemoveAsync(userName);
        }

        public async Task<ShoppingCart> GetSatelliteOrchestrator(string userName)
        {
            var SatelliteOrchestrator = await _redisCache.GetStringAsync(userName);

            if (String.IsNullOrEmpty(SatelliteOrchestrator))
                return null;

            return JsonConvert.DeserializeObject<ShoppingCart>(SatelliteOrchestrator);
        }

        public async Task<ShoppingCart> UpdateSatelliteOrchestrator(ShoppingCart SatelliteOrchestrator)
        {
            await _redisCache.SetStringAsync(SatelliteOrchestrator.UserName, JsonConvert.SerializeObject(SatelliteOrchestrator));
            return await GetSatelliteOrchestrator(SatelliteOrchestrator.UserName);
        }
    }
}
