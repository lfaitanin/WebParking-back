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
        private readonly MongoClient client;
        IMongoDatabase _db;

        public ParkingContext(IConfiguration config)
        {
            _configuration = config;
            client = new MongoClient(_configuration.GetConnectionString("MongoConnection"));
            _db = client.GetDatabase("heroku_b7x779xn");
        }

        public T GetItem<T>(string codigo)
        {
            var filter = Builders<T>.Filter.Eq("Code", codigo);

            return _db.GetCollection<T>("ParkingDb")
                .Find(filter).FirstOrDefault();
        }

        public Parking AddItem(Parking parking)
        {
            var parkingDb = _db.GetCollection<Parking>("ParkingDb");
            parkingDb.InsertOne(parking);
            return parking;
        }

        public R RemoveItem<R>(string codigo)
        {
            var a = Builders<R>.Filter.Eq("Code", codigo);
            return _db.GetCollection<R>("ParkingDb")
               .FindOneAndDelete(a);
        }

        public List<Parking> GetAll()
        {
            //Executar o drop toda vez que a estrutura do objeto Parking mudar.
            //_db.DropCollection("Parking");
            var filter = Builders<Parking>.Filter.Empty;

            return _db.GetCollection<Parking>("ParkingDb").Find(filter).ToList();
        }
    }
}
