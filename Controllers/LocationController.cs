using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Parkingspot.Models;

namespace Parkingspot.Controllers
{
    [Route("api/[Controller]")]
    public class LocationController : ControllerBase
    {
        public readonly string URL_GET_LAT_LONG = "http://geocoder.api.here.com/6.2/";
        public readonly string HereAppId = "MOoAGnNIBrHgC51qjnDC";
        public readonly string HereAppCode = "5SwcjloK8L5OxUHhwJ7aIw";
        public readonly string URL_UBER_PRICE = "https://api.uber.com/v1.2/estimates/";
        public readonly string client_id = "aZzkvx6cJ71tD2vl7xAl6ghkUNhd86-5";
        public readonly string client_secret = "oQg_TZE_dt0aSQ32snGbUTx531S_xLkX4gik_8Lh";
        public readonly string server_token = "XTKq_9Ng91lsVjvetLV_k9etasRrS8i410iARprf";

        [HttpGet]
        [Route("GetSuggestions/{location}")]
        public IActionResult GetSuggestions(string location)
        {
            var urlToGetSuggestions = string.Format(
                    "http://autocomplete.geocoder.api.here.com/6.2/suggest.json?query={0}" +
                    "&app_id={1}" +
                    "&app_code={2}", location, HereAppId, HereAppCode);

            var places = new List<Address>();
            HttpClient client = new HttpClient();
            var matches = client.GetStringAsync(urlToGetSuggestions).Result;

            var matchesJson = JsonConvert.DeserializeObject<Suggestions>(matches);
            foreach (var place in matchesJson.suggestions)
            {
                places.Add(new Address
                {
                    City = place.Address.City,
                    Country = place.Address.Country,
                    State = place.Address.State,
                    LocationId = place.locationId,
                    DisplayName = $"{place.label}, {place.Address.State}",
                    FullDisplayName = $"{place.label}, {place.Address.State}, {place.Address.Country}",
                });
            }

            return Ok(places);
        }
    }
}