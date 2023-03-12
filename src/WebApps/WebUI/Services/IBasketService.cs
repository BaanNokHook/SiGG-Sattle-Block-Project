using WebUI.Models;
using System.Threading.Tasks;

namespace WebUI.Services
{
    public interface ISatelliteOrchestratorService
    {
        Task<SatelliteOrchestratorModel> GetSatelliteOrchestrator(string userName);
        Task<SatelliteOrchestratorModel> UpdateSatelliteOrchestrator(SatelliteOrchestratorModel model);
        Task CheckoutSatelliteOrchestrator(SatelliteOrchestratorCheckoutModel model);
    }
}
