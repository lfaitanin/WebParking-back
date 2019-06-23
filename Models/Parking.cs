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
        public string Adress { get; set; }
        //public string Photo { get; set; }
        //public float Price { get; set; }
        //public double Coordinates { get; set; }
        //public bool Discount { get; set; }

    }
}
