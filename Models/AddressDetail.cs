using MongoDB.Bson;
using System.Collections.Generic;

namespace Parkingspot.Models
{
    public class AddressDetail
    {
        Address Address { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
    }
}
