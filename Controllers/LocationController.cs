using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Parkingspot.Models;
using System.Collections.Generic;
using System.Net.Http;

namespace Parkingspot.Controllers
{
    [Route("api/[Controller]")]
    public class LocationController : ControllerBase
    {
        public readonly string URL_GET_LAT_LONG = "http://geocoder.api.here.com/6.2/";
        public readonly string HereAppId = "MOoAGnNIBrHgC51qjnDC";
        public readonly string HereAppCode = "5SwcjloK8L5OxUHhwJ7aIw";

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