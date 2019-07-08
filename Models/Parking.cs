using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using DnsClient.Protocol;

namespace Parkingspot.Models
{
    public class Parking
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string ParkingName { get; set; }
        public Address Address { get; set; }
        public string LocationId { get; set; }
        public PriceProvider Price { get; set; }
        public string[] Coordinates { get; set; }
        public bool HasDiscount { get; set; }
        [BsonDateTimeOptions]
        public DateTime UpdatedOn { get; set; } = DateTime.Now;

    }
    public class PriceProvider
    {
        public decimal FirstHour { get; set; }
        public decimal EveryHour { get; set; }
        public decimal Daily { get; set; }
        public decimal Monthly { get; set; } 

    }

}
