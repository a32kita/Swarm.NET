using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace SwarmDotNET.Entities
{
    public class VenueLocation
    {
        [JsonProperty(PropertyName = "address")]
        public string Address
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "lat")]
        public double Lat
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "lng")]
        public double Lng
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "postalCode")]
        public string PostalCode
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "cc")]
        public string Cc
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "city")]
        public string City
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "state")]
        public string State
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "country")]
        public string Country
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "neighborhood")]
        public string Neighborhood
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "crossStreet")]
        public string CrossStreet
        {
            get;
            set;
        }
    }
}
