using MongoDB.Bson;
using System.Collections.Generic;

namespace Parkingspot.Models
{
    public class Parking
    {
        public ObjectId _id { get; set; }

        public string Code { get; set; }
        public string ParkingName { get; set; }
        public string Adress { get; set; }
        public double Price { get; set; }
        public string[] Coordinates { get; set; }
        public bool HasDiscount { get; set; }
    }
}
