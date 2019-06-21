using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parkingspot.Models
{
    public class Clientes
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
        public long Id { get; set; }
        public string Adress { get; set; }
        public string Photo { get; set; }
        public float Price { get; set; }
        public double Coordinates { get; set; }
        public bool Discount { get; set; }

    }
}
