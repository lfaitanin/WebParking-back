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

        public ClientesContext()
        {
            new MongoClient("mongodb://root:example@localhost:27017/db-name?connect=clientes");

        }

        public IMongoCollection<Clientes> Cliente => _db.GetCollection<Clientes>("Clientes");

    }
}
