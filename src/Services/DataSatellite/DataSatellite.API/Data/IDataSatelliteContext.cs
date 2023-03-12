using DataSatellite.API.Entities;
using MongoDB.Driver;

namespace DataSatellite.API.Data
{
    public interface IDataSatelliteContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
