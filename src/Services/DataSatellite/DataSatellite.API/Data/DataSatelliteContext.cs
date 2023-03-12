using DataSatellite.API.Entities;
using MongoDB.Driver;

namespace DataSatellite.API.Data
{
    public class DataSatelliteContext : IDataSatelliteContext
    {
        public DataSatelliteContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase("DatabaseSettings:DatabaseName");

            Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            DataSatelliteContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; }
    }
}
