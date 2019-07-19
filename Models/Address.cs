using MongoDB.Bson;
using System.Collections.Generic;

namespace Parkingspot.Models
{
    public class Address
    {
        public string State { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string District { get; set; }
        public string LocationId { get; set; }
        public string DisplayName { get; set; }
        public string FullDisplayName { get; set; }
    }
}
