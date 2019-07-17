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
    public class UserContext : IUserContext
    {
        private IConfiguration _configuration;
        private readonly MongoClient client;
        private IMongoDatabase _db;
        private IMongoCollection<User> ParkingCollection;

        public UserContext(IConfiguration config)
        {
            _configuration = config;
            client = new MongoClient(_configuration.GetConnectionString("MongoConnection"));
            _db = client.GetDatabase("heroku_b7x779xn");
            ParkingCollection = _db.GetCollection<User>("UserDb");
        }
        
        public List<User> GetAll()
        {
            //Executar o drop toda vez que a estrutura do objeto Parking mudar.
            //_db.DropCollection("UserDb");
            var filter = Builders<User>.Filter.Empty;

            return ParkingCollection.Find(filter).ToList();
        }

        public void AddUser(User user)
        {
            ParkingCollection.InsertOne(user);
        }
    }

}
