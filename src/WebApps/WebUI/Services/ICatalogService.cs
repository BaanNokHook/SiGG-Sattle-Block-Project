using WebUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebUI.Services
{
    public interface IDataSatelliteService
    {
        Task<IEnumerable<DataSatelliteModel>> GetDataSatellite();
        Task<IEnumerable<DataSatelliteModel>> GetDataSatelliteByCategory(string category);
        Task<DataSatelliteModel> GetDataSatellite(string id);
        Task<DataSatelliteModel> CreateDataSatellite(DataSatelliteModel model);
    }
}