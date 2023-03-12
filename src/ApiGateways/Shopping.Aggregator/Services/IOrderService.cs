using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services
{
    public interface ISatelliteOrchestratorControllerService
    {
        Task<IEnumerable<SatelliteOrchestratorControllerResponseModel>> GetSatelliteOrchestratorControllersByUserName(string userName);
    }
}