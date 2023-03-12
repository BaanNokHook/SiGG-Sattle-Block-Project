using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services
{
    public interface ISatelliteOrchestratorService
    {
        Task<SatelliteOrchestratorModel> GetSatelliteOrchestrator(string userName);
    }
}