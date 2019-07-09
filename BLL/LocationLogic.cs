using Newtonsoft.Json;
using Parkingspot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Parkingspot.BLL
{
    public class LocationLogic : ILocationLogic
    {
        public readonly string URL_GET_LAT_LONG = "http://geocoder.api.here.com/6.2/";
        public readonly string HereAppId = "MOoAGnNIBrHgC51qjnDC";
        public readonly string HereAppCode = "5SwcjloK8L5OxUHhwJ7aIw";
        public readonly string URL_UBER_PRICE = "https://api.uber.com/v1.2/estimates/";
        public readonly string client_id = "aZzkvx6cJ71tD2vl7xAl6ghkUNhd86-5";
        public readonly string client_secret = "oQg_TZE_dt0aSQ32snGbUTx531S_xLkX4gik_8Lh";
        public readonly string server_token = "XTKq_9Ng91lsVjvetLV_k9etasRrS8i410iARprf";

        public double[] GetCoordinates(string LocationId)
        {
            var urlToGetDetails = URL_GET_LAT_LONG +
                string.Format("geocode.json?locationid={0}&jsonattributes=1&gen=9" +
                    "&app_id={1}" +
                    "&app_code={2}", LocationId, HereAppId, HereAppCode);

            HttpClient client = new HttpClient();
            var matches = client.GetStringAsync(urlToGetDetails).Result;
            var placeDetail = JsonConvert.DeserializeObject<AddressDetails>(matches);
            //Deserializar aqui e retornar para calcular os preços
            var coordinates = new double[]
            {
                placeDetail.response.view[0].result[0].location.displayPosition.latitude,
                placeDetail.response.view[0].result[0].location.displayPosition.longitude
            };

            return coordinates;
        }
    }
}
