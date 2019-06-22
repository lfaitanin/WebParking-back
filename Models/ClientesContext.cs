using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Parkingspot.Config;

namespace Parkingspot.Models
{
    public class ClientesContext : IClientesContext
    {
        private readonly IMongoDatabase _db;

        public ClientesContext(MongoDBConfig config)
        {
            var client = new MongoClient(config.ConnectionString);
            _db = client.GetDatabase(config.Database);
        }

        public IMongoCollection<Clientes> Cliente => _db.GetCollection<Clientes>("Clientes");

    }
}
