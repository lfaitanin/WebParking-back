using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Parkingspot.Models;
using System.Linq;

namespace Parkingspot.Context
{
    public class ParkingContext : IParkingContext
    {
        private IConfiguration _configuration;
        private readonly MongoClient client = new MongoClient();
        IMongoDatabase _db;

        public ParkingContext(IConfiguration config)
        {
            _configuration = config;
            _configuration.GetConnectionString("MongoConnection");
            _db = client.GetDatabase("ParkingDB");
        }

        public T GetItem<T>(string codigo)
        {
            var filter = Builders<T>.Filter.Eq("Code", codigo);

            return _db.GetCollection<T>("Parking")
                .Find(filter).FirstOrDefault();
        }

        public Parking AddItem(Parking parking)
        {
            var parkingDb = _db.GetCollection<Parking>("Parking");
            parkingDb.InsertOne(parking);
            return parking;
        }
    }
}
