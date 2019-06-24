using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Parkingspot.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Parkingspot.Context
{
    public class ParkingContext : IParkingContext
    {
        private IConfiguration _configuration;
        private readonly ParkingContext _context = null;
         private readonly MongoClient client = new MongoClient();
        IMongoDatabase _db;
        public IMongoCollection<Parking> Parkings {
            get {
                return _db.GetCollection<Parking>("ParkingDB");
            }
        }

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

        public R RemoveItem<R>(string codigo)
        {
            var a = Builders<R>.Filter.Eq("Code", codigo);
             return _db.GetCollection<R>("Parking")
                .FindOneAndDelete(a);
        }

     
        public async Task<IEnumerable<Parking>> GetAllProducts()
        {
            return await _context.Parkings.Find(_ => true).ToListAsync();
        }
    }
}
