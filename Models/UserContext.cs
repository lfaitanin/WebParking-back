using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Parkingspot.Config;

namespace Parkingspot.Models
{

    public class UserContext : IUserContext
    {
        private readonly IMongoDatabase _db;

        public UserContext(MongoDBConfig config)
        {
            var client = new MongoClient(config.ConnectionString);
            _db = client.GetDatabase(config.Database);
        }

        public IMongoCollection<User> Users => _db.GetCollection<User>("Users");
    }
}
