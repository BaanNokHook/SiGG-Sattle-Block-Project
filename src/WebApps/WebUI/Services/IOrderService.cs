using WebUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebUI.Services
{
    public interface ISatelliteOrchestratorControllerService
    {
        Task<IEnumerable<SatelliteOrchestratorControllerResponseModel>> GetSatelliteOrchestratorControllersByUserName(string userName);
    }

}
