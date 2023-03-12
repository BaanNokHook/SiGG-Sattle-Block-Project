using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services
{
    public interface IDataSatelliteService
    {
        Task<IEnumerable<DataSatelliteModel>> GetDataSatellite();
        Task<IEnumerable<DataSatelliteModel>> GetDataSatelliteByCategory(string category);
        Task<DataSatelliteModel> GetDataSatellite(string id);
    }
}