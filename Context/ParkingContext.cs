using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
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
    public class ParkingContext
    {
        private readonly IMongoCollection<Parking> _parkingCollection;

        public ParkingContext(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("ParkingConnection"));
            var database = client.GetDatabase("ParkingDb");

            _parkingCollection = database.GetCollection<Parking>("Parkings");
        }
        public List<Parking> Get()
        {
            return _parkingCollection.Find(parking => true).ToList();
        }

        public Parking Get(string id)
        {
            return _parkingCollection.Find(parking => parking.Code == id).FirstOrDefault();
        }
        public Parking Create(Parking parking)
        {
            _parkingCollection.InsertOne(parking);
            return parking;
        }
        public void Update(string id, Parking newParking)
        {
            _parkingCollection.ReplaceOne(parking => parking.Code == id, newParking);
        }
        public void Remove(string id)
        {
            _parkingCollection.DeleteOne(parking => parking.Code == id);
        }
    }
}
