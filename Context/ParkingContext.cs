using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using Parkingspot.Models;
using System;
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
        private IMongoDatabase _db;
        private IMongoCollection<Parking> ParkingCollection;

        public ParkingContext(IConfiguration config)
        {
            _configuration = config;
            client = new MongoClient(_configuration.GetConnectionString("MongoConnection"));
            _db = client.GetDatabase("heroku_b7x779xn");
            ParkingCollection = _db.GetCollection<Parking>("ParkingDb");
        }


        public async Task<Parking> GetParking(string id)
        {
            var filter = Builders<Parking>.Filter.Eq("id", id);
            return await ParkingCollection
                .Find(filter)
                .FirstOrDefaultAsync();
        }

        public Parking AddItem(Parking parking)
        {

            ParkingCollection.InsertOne(parking);
            return parking;
        }

        public bool RemoveItem(string id)
        {
            try
            {
                var itemToBeDeleted = Builders<Parking>.Filter.Eq("id", id);
                ParkingCollection.FindOneAndDelete(itemToBeDeleted);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Parking> GetAll()
        {
            //Executar o drop toda vez que a estrutura do objeto Parking mudar.
            //_db.DropCollection("ParkingDb");
            var filter = Builders<Parking>.Filter.Empty;

            return ParkingCollection.Find(filter).ToList();
        }

        public void Update(string id, Parking parkingIn)
        {
            ParkingCollection.ReplaceOne(parking => parking.id == id, parkingIn);
        }
    }

}
