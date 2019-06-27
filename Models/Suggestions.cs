using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parkingspot.Models
{
    public class Suggestions
    {
        public List<Suggestion> suggestions { get; set; }
    }

    public class Suggestion
    {
        public string label { get; set; }
        public string language { get; set; }
        public string countryCode { get; set; }
        public string locationId { get; set; }
        public Address Address { get; set; }
        public string matchLevel { get; set; }
    }
}
