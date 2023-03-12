using SatelliteOrchestrator.API.Entities;

namespace SatelliteOrchestrator.API.Repositories
{
    public interface ISatelliteOrchestratorRepository
    {
        Task<ShoppingCart> GetSatelliteOrchestrator(string userName);
        Task<ShoppingCart> UpdateSatelliteOrchestrator(ShoppingCart SatelliteOrchestrator);
        Task DeleteSatelliteOrchestrator(string userName); 

    }
}
