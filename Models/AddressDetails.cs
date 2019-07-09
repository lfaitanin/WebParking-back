using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace Parkingspot.Models
{
    public class AddressDetails
    {
        public Response response { get; set; }
    }

    public class MetaInfo
    {
        public DateTime timestamp { get; set; }
    }

    public class DisplayPosition
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class TopLeft
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class BottomRight
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class MapView
    {
        public TopLeft topLeft { get; set; }
        public BottomRight bottomRight { get; set; }
    }

    public class AdditionalData
    {
        public string value { get; set; }
        public string key { get; set; }
    }

    public class AddressDetail
    {
        public string label { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string postalCode { get; set; }
        public List<AdditionalData> additionalData { get; set; }
    }

    public class Location
    {
        public string locationId { get; set; }
        public string locationType { get; set; }
        public DisplayPosition displayPosition { get; set; }
        public MapView mapView { get; set; }
        public AddressDetail address { get; set; }
    }

    public class Result
    {
        public double relevance { get; set; }
        public string matchLevel { get; set; }
        public Location location { get; set; }
    }

    public class View
    {
        public List<Result> result { get; set; }
        public int viewId { get; set; }
    }

    public class Response
    {
        public MetaInfo metaInfo { get; set; }
        public List<View> view { get; set; }
    }
}
