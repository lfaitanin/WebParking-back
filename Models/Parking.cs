using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parkingspot.Models
{


    public class Parking
    {
        public ObjectId _id { get; set; }
        public string Code { get; set; }
        public string ParkingName { get; set; }
        public string Adress { get; set; }
        public double Price { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool HasDiscount { get; set; }
    }
}
